Imports System.ComponentModel
Imports System.Threading
Imports System.Threading.Tasks

'Contains a traffic light state configuration.
Public Class State
    Private WithEvents _stateThread As Thread
    Private ReadOnly _trafficLightList As List(Of TrafficLight)
    Public Property AffectedTrafficLightList As List(Of TrafficLight)
    Public Property ConflictingBusTrafficLightList As List(Of TrafficLight)
    Public Property Id As Integer
    Private _maxQueue As Integer
    Private _mainWindow As MainWindow
    Private _threadStarted As Byte

    Sub New(ByRef trafficLightList As List(Of TrafficLight))
        _trafficLightList = trafficLightList

        AffectedTrafficLightList = New List(Of TrafficLight)()
        'List of traffic lights that are conflicting with bus traffic lights.
        ConflictingBusTrafficLightList = New List(Of TrafficLight)()
    End Sub

    Public Sub StartState(ByVal mainWindow As MainWindow, ByVal maxQueue As Integer)

        _mainWindow = mainWindow
        _maxQueue = maxQueue

        If _stateThread Is Nothing Then
            'Create a new thread.
            _stateThread = New Thread(AddressOf StateWorker)
            _stateThread.IsBackground = True
            _stateThread.Start()
        End If

    End Sub

    Public Sub StopState()

        'Stop the controller if it started.
        If _stateThread IsNot Nothing AndAlso _stateThread.IsAlive() Then
            Thread.VolatileWrite(_threadStarted, 0)
        End If
    End Sub

    'Get the thread object.
    Public Function GetThread() As Thread
        Return _stateThread
    End Function

    'Thread worker.
    Private Sub StateWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        _mainWindow.LogMessage(1, "Executing state " + Id.ToString() + "...")
        _mainWindow.UpdateCurrentStateLabel(Id.ToString())

        Dim stopwatch As Stopwatch = stopwatch.StartNew()

        Dim pedestrianCyclistPending As Boolean

        'Check if cyclists or pedestrians are waiting.
        For Each trafficLight As TrafficLight In AffectedTrafficLightList
            If trafficLight.Type = 2 Then
                If trafficLight.GetVehicleCount() > 0 Then
                    pedestrianCyclistPending = True
                End If
            End If
        Next

        'Sets all traffic lights to green.
        If Thread.VolatileRead(_threadStarted) = 1 Then
            _mainWindow.LogMessage(1, "Changing all affected traffic lights to green.")

            Parallel.ForEach(_trafficLightList, Sub(trafficLight)
                                                    If AffectedTrafficLightList.Contains(trafficLight) Then

                                                        Dim excluded As Boolean
                                                        If TrafficLightController.PreviousState IsNot Nothing Then
                                                            'Check if the previous state contains the same traffic light.
                                                            If TrafficLightController.PreviousState.AffectedTrafficLightList.Contains(trafficLight) Then

                                                                _mainWindow.LogMessage(1, "Traffic light " + trafficLight.Id.ToString() + " was excluded from switching to green.")
                                                                excluded = True
                                                            End If
                                                        End If

                                                        If ConflictingBusTrafficLightList.Contains(trafficLight) Then
                                                            trafficLight.ChangeStateToRed()

                                                            excluded = True
                                                        End If

                                                        'Change the traffic light state.
                                                        If Not excluded Then
                                                            If trafficLight.Type = 2 Then
                                                                If pedestrianCyclistPending Then
                                                                    trafficLight.ChangeStateToGreen()
                                                                Else
                                                                    If Not My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled Then
                                                                        trafficLight.ChangeStateToGreen()
                                                                    End If
                                                                End If
                                                            Else
                                                                trafficLight.ChangeStateToGreen()
                                                            End If
                                                        End If
                                                    Else
                                                        If trafficLight.State <> 0 Then
                                                            trafficLight.ChangeStateToRed()
                                                        End If
                                                    End If
                                                End Sub)
        End If

        If Thread.VolatileRead(_threadStarted) = 1 Then
            If ConflictingBusTrafficLightList.Count > 0 Then

                Dim maxConflictingTrafficLightQueue As Integer

                For Each trafficLight In AffectedTrafficLightList
                    If trafficLight.Type = 3 Then
                        If trafficLight.GetVehicleCount() >= maxConflictingTrafficLightQueue Then
                            maxConflictingTrafficLightQueue = trafficLight.GetVehicleCount()
                        End If
                    End If
                Next

                stopwatch.Reset()
                stopwatch.Start()
                Do
                    If Thread.VolatileRead(_threadStarted) = 0 Then
                        Exit Do
                    End If
                    If stopwatch.ElapsedMilliseconds >= ((My.Settings.ConflictingBusTrafficLightDelay * 1000) * maxConflictingTrafficLightQueue) Then
                        Exit Do
                    End If

                    _mainWindow.UpdateTimerLabel(stopwatch.Elapsed.TotalSeconds.ToString())
                    Thread.Sleep(100)
                Loop
                stopwatch.Stop()

                For Each trafficLight In AffectedTrafficLightList

                    If ConflictingBusTrafficLightList.Contains(trafficLight) Then
                        trafficLight.ChangeStateToGreen()
                    End If

                    If trafficLight.Type = 3 Then
                        trafficLight.ChangeStateToRed()
                    End If
                Next
            End If
        End If

        If Thread.VolatileRead(_threadStarted) = 1 Then
            'Calculate the max queue size.
            _mainWindow.LogMessage(5, "Delay based on queue: " + _maxQueue.ToString() + ", + standard " + My.Settings.GreenToOrangeDelay.ToString() + " seconds = " + ((_maxQueue * My.Settings.ExtraVehicleDelay) + My.Settings.GreenToOrangeDelay).ToString() + ".")
            _mainWindow.LogMessage(1, "Waiting " + (My.Settings.GreenToOrangeDelay + (_maxQueue * My.Settings.ExtraVehicleDelay)).ToString() + " seconds before changing all affected traffic lights to orange.")

            stopwatch.Reset()
            stopwatch.Start()
            Do
                If Thread.VolatileRead(_threadStarted) = 0 Then
                    Exit Do
                End If
                If stopwatch.ElapsedMilliseconds >= (My.Settings.GreenToOrangeDelay * 1000) + ((_maxQueue * My.Settings.ExtraVehicleDelay) * 1000) Then
                    Exit Do
                End If

                _mainWindow.UpdateTimerLabel(stopwatch.Elapsed.TotalSeconds.ToString())
                Thread.Sleep(100)
            Loop
            stopwatch.Stop()

            'Sets all traffic lights to orange.
            Parallel.ForEach(AffectedTrafficLightList, Sub(trafficLight)

                                                           Dim excluded As Boolean

                                                           If TrafficLightController.NextState IsNot Nothing Then
                                                               If TrafficLightController.NextState.AffectedTrafficLightList.Contains(trafficLight) Then
                                                                   excluded = True
                                                                   _mainWindow.LogMessage(1, "Traffic light " + trafficLight.Id.ToString() + " was excluded from switching to orange.")
                                                               End If
                                                           End If

                                                           If Not excluded Then
                                                               If trafficLight.Type = 2 Then
                                                                   If pedestrianCyclistPending Then
                                                                       trafficLight.ChangeStateToOrange()
                                                                   Else
                                                                       If Not My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled Then
                                                                           trafficLight.ChangeStateToOrange()
                                                                       End If
                                                                   End If
                                                               Else
                                                                   trafficLight.ChangeStateToOrange()
                                                               End If
                                                           End If
                                                       End Sub)
        End If

        If Thread.VolatileRead(_threadStarted) = 1 Then
            _mainWindow.LogMessage(1, "Waiting " + My.Settings.OrangeToRedDelay.ToString() + " seconds before changing all affected traffic lights to red.")

            stopwatch.Reset()
            stopwatch.Start()
            Do
                If Thread.VolatileRead(_threadStarted) = 0 Then
                    Exit Do
                End If
                If stopwatch.ElapsedMilliseconds >= (My.Settings.OrangeToRedDelay * 1000) Then
                    Exit Do
                End If

                _mainWindow.UpdateTimerLabel(stopwatch.Elapsed.TotalSeconds.ToString())
                Thread.Sleep(100)
            Loop
            stopwatch.Stop()

            'Sets all traffic lights to red.
            Parallel.ForEach(AffectedTrafficLightList, Sub(trafficLight)

                                                           Dim excluded As Boolean

                                                           If TrafficLightController.NextState IsNot Nothing Then
                                                               If TrafficLightController.NextState.AffectedTrafficLightList.Contains(trafficLight) Then
                                                                   excluded = True
                                                                   _mainWindow.LogMessage(1, "Traffic light " + trafficLight.Id.ToString() + " was excluded from switching to red.")
                                                               End If
                                                           End If

                                                           If Not excluded Then
                                                               If trafficLight.Type = 2 Then
                                                                   If pedestrianCyclistPending Then
                                                                       trafficLight.ChangeStateToRed()
                                                                   Else
                                                                       If Not My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled Then
                                                                           trafficLight.ChangeStateToRed()
                                                                       End If
                                                                   End If
                                                               Else
                                                                   trafficLight.ChangeStateToRed()
                                                               End If
                                                           End If
                                                       End Sub)

            If Thread.VolatileRead(_threadStarted) = 1 Then
                _mainWindow.LogMessage(1, "Keeping traffic lights on red for " + My.Settings.StateDelay.ToString() + " seconds.")

                stopwatch.Reset()
                stopwatch.Start()
                Do
                    If Thread.VolatileRead(_threadStarted) = 0 Then
                        Exit Do
                    End If
                    If stopwatch.ElapsedMilliseconds >= (My.Settings.StateDelay * 1000) Then
                        Exit Do
                    End If

                    _mainWindow.UpdateTimerLabel(stopwatch.Elapsed.TotalSeconds.ToString())
                    Thread.Sleep(100)
                Loop
                stopwatch.Stop()
            End If
        End If

        If Thread.VolatileRead(_threadStarted) = 1 Then
            _mainWindow.LogMessage(1, "Finished executing state " + Id.ToString() + ".")
        Else
            _mainWindow.LogMessage(1, "Aborted state " + Id.ToString() + ".")
        End If

        _mainWindow.UpdateCurrentStateLabel(Nothing)
        _stateThread = Nothing
    End Sub

End Class
