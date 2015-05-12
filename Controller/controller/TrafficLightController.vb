Imports System.ComponentModel
Imports System.Threading

Public Module TrafficLightController
    Private WithEvents _trafficLightControllerThread As Thread
    Private ReadOnly StateList As List(Of State)
    Private _threadStarted As Byte
    Public Property FirstAnnouncement As Byte
    Private _maxQueue As Integer
    Private _mainWindow As MainWindow

    Sub New()
        StateList = New List(Of State)()

        '2
        '1
        '3
        '4
        Dim state1 As New State(Controller.TrafficLightList)
        state1.Sequence = 1
        state1.AffectedTrafficLightList.Add(Controller.TrafficLightList(2))
        state1.AffectedTrafficLightList.Add(Controller.TrafficLightList(4))
        state1.AffectedTrafficLightList.Add(Controller.TrafficLightList(5))
        StateList.Add(state1)

        Dim state2 As New State(Controller.TrafficLightList)
        state2.Sequence = 2
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(0))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(3))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(43))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(47))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(44))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(45))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(15))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(16))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(46))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(50))
        StateList.Add(state2)

        Dim state3 As New State(Controller.TrafficLightList)
        state3.Sequence = 3
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(38))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(32))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(37))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(31))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(36))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(33))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(34))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(35))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(1))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(5))
        StateList.Add(state3)

        Dim state4 As New State(Controller.TrafficLightList)
        state4.Sequence = 4
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(2))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(4))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(26))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(27))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(28))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(25))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(49))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(29))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(48))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(30))
        StateList.Add(state4)
    End Sub


    Public Sub StartTrafficLightController()

        If _trafficLightControllerThread Is Nothing Then
            'Create a new thread.
            _trafficLightControllerThread = New Thread(AddressOf TrafficLightControllerWorker)
            _trafficLightControllerThread.IsBackground = True
            _trafficLightControllerThread.Start()
        Else
            _mainWindow.LogMessage(1, "Traffic Light Controller is already started.")
        End If
    End Sub

    Public Sub StopTrafficLightController()
        'Stop the controller if it started.
        If _trafficLightControllerThread IsNot Nothing AndAlso _trafficLightControllerThread.IsAlive() Then
            Thread.VolatileWrite(_threadStarted, 0)

            _mainWindow.UpdateTimerLabel(Nothing)
        Else
            _mainWindow.LogMessage(1, "Traffic Light Controller has not been started.")
        End If
    End Sub

    Private Sub TrafficLightControllerWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        _mainWindow.LogMessage(1, "Traffic Light Controller started.")

        Dim stopwatch As Stopwatch = stopwatch.StartNew()

        While Thread.VolatileRead(_threadStarted) = 1

            If Thread.VolatileRead(FirstAnnouncement) = 0 Then
                _mainWindow.LogMessage(1, "Waiting for the first traffic announcement to arrive...")

                While Thread.VolatileRead(FirstAnnouncement) = 0
                    If Thread.VolatileRead(_threadStarted) = 0 Then
                        Exit While
                    End If
                    Thread.Sleep(10)
                End While
            End If

            For Each state In StateList

                If Thread.VolatileRead(_threadStarted) = 1 Then
                    _maxQueue = 0

                    For Each trafficLight In state.AffectedTrafficLightList
                        If trafficLight.GetVehicleCount() > _maxQueue Then
                            _maxQueue = _maxQueue + trafficLight.GetVehicleCount()
                        End If
                    Next

                    _mainWindow.LogMessage(5, "Longest queue: " + _maxQueue.ToString() + ".")

                    state.StartState(_mainWindow, _maxQueue)
                End If

                If Thread.VolatileRead(_threadStarted) = 1 Then
                    _mainWindow.LogMessage(5, "Waiting for state " + state.Sequence.ToString() + " to finish.")

                    While state.GetThread() IsNot Nothing AndAlso state.GetThread().IsAlive
                        If Thread.VolatileRead(_threadStarted) = 0 Then
                            Exit While
                        End If

                        Thread.Sleep(10)
                    End While

                    If Thread.VolatileRead(_threadStarted) = 1 Then

                        If state.GetThread() IsNot Nothing Then
                            state.GetThread().Join()
                        End If
                    End If
                End If
            Next

            If Thread.VolatileRead(_threadStarted) = 1 Then
                _mainWindow.LogMessage(1, "Processed all states. Starting over.")
            End If
        End While

        For Each state In StateList
            If state IsNot Nothing Then

                state.StopState()
                If state.GetThread() IsNot Nothing Then
                    If state.GetThread().IsAlive Then
                        state.GetThread.Join()
                    End If
                End If

                state = Nothing
            End If
        Next

        Thread.VolatileWrite(FirstAnnouncement, 0)

        _mainWindow.LogMessage(1, "Traffic Light Controller stopped.")
        _trafficLightControllerThread = Nothing
    End Sub

    Public Function GetThread() As Thread
        Return _trafficLightControllerThread
    End Function

    Public Function CheckTrafficLightControllerStarted() As Boolean
        If _trafficLightControllerThread IsNot Nothing Then
            If _trafficLightControllerThread.IsAlive() Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Sub ResetMaxQueue()
        _maxQueue = 0
    End Sub

    Public Sub SetMainWindow(ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
    End Sub

End Module
