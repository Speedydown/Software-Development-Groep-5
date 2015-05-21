Imports System.ComponentModel
Imports System.Threading
Imports System.Threading.Tasks

Public Class State
    Private WithEvents _stateThread As Thread
    Private ReadOnly _trafficLightList As List(Of TrafficLight)
    Public Property AffectedTrafficLightList As List(Of TrafficLight)
    Public Property Id As Integer
    Private _maxQueue As Integer
    Private _mainWindow As MainWindow
    Private _threadStarted As Byte

    Sub New(ByRef trafficLightList As List(Of TrafficLight))
        _trafficLightList = trafficLightList

        AffectedTrafficLightList = New List(Of TrafficLight)()
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

    Public Function GetThread() As Thread
        Return _stateThread
    End Function

    Private Sub StateWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        _mainWindow.LogMessage(1, "Executing state " + Id.ToString() + "...")

        Dim stopwatch As Stopwatch = stopwatch.StartNew()

        Dim walkerCyclistPending As Boolean

        For Each trafficLight As TrafficLight In AffectedTrafficLightList
            If trafficLight.Type = 2 Then
                If trafficLight.GetVehicleCount() > 0 Then
                    walkerCyclistPending = True
                End If
            End If
        Next


        If Thread.VolatileRead(_threadStarted) = 1 Then
            _mainWindow.LogMessage(1, "Changing all affected traffic lights to green.")

            Parallel.ForEach(_trafficLightList, Sub(trafficLight)
                                                    If AffectedTrafficLightList.Contains(trafficLight) Then

                                                        Dim excluded As Boolean
                                                        If TrafficLightController.PreviousState IsNot Nothing Then
                                                            If TrafficLightController.PreviousState.AffectedTrafficLightList.Contains(trafficLight) Then

                                                                _mainWindow.LogMessage(1, "Traffic light " + trafficLight.Id.ToString() + " was excluded from switching to green.")
                                                                excluded = True
                                                            End If
                                                        End If

                                                        If Not excluded Then
                                                            If trafficLight.Type = 2 Then
                                                                If walkerCyclistPending Then
                                                                        trafficLight.ChangeStateToGreen()
                                                                Else
                                                                    If Not My.Settings.WalkerCyclistTrafficLightsAlwaysEnabled Then
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
                                                                   If walkerCyclistPending Then
                                                                       trafficLight.ChangeStateToOrange()
                                                                   Else
                                                                       If Not My.Settings.WalkerCyclistTrafficLightsAlwaysEnabled Then
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
                                                                   If walkerCyclistPending Then
                                                                       trafficLight.ChangeStateToRed()
                                                                   Else
                                                                       If Not My.Settings.WalkerCyclistTrafficLightsAlwaysEnabled Then
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

        _stateThread = Nothing
    End Sub

End Class
