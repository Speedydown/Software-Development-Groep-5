Imports System.ComponentModel
Imports System.Threading
Imports System.Threading.Tasks

Public Module TrafficLightController
    Private WithEvents _trafficLightControllerThread As Thread
    Private ReadOnly StateList As List(Of State)
    Private ReadOnly BusStateList As List(Of State)
    Public Property PreviousState As State
    Public Property NextState As State
    Public Property FirstAnnouncement As Byte
    Private _previousBusState As Boolean
    Private _busStateQueued As Boolean
    Private _test As Boolean

    Private _nonBusStatesPassed As Integer
    Private _threadStarted As Byte
    Private _maxQueue As Integer
    Private _mainWindow As MainWindow
    Private _firstRun As Boolean
    ReadOnly Random As New Random()

    Sub New()
        StateList = New List(Of State)()

        '2
        '1
        '3
        '4
        Dim state1 As New State(Controller.TrafficLightList)
        state1.Id = 1
        state1.AffectedTrafficLightList.Add(Controller.TrafficLightList(2))
        state1.AffectedTrafficLightList.Add(Controller.TrafficLightList(4))
        state1.AffectedTrafficLightList.Add(Controller.TrafficLightList(5))
        StateList.Add(state1)

        Dim state2 As New State(Controller.TrafficLightList)
        state2.Id = 2
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(0))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(3))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(44))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(45))

        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(46))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(50))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(15))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(16))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(43))
        state2.AffectedTrafficLightList.Add(Controller.TrafficLightList(47))
        StateList.Add(state2)

        Dim state3 As New State(Controller.TrafficLightList)
        state3.Id = 3

        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(31))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(33))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(1))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(5))

        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(35))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(34))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(36))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(37))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(38))
        state3.AffectedTrafficLightList.Add(Controller.TrafficLightList(32))
        StateList.Add(state3)

        Dim state4 As New State(Controller.TrafficLightList)
        state4.Id = 4
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(2))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(4))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(28))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(29))

        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(48))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(30))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(25))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(49))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(26))
        state4.AffectedTrafficLightList.Add(Controller.TrafficLightList(27))
        StateList.Add(state4)

        BusStateList = New List(Of State)()

        Dim busState1 As New State(Controller.TrafficLightList)
        busState1.Id = 5
        busState1.AffectedTrafficLightList.Add(Controller.TrafficLightList(2))
        busState1.AffectedTrafficLightList.Add(Controller.TrafficLightList(4))
        busState1.AffectedTrafficLightList.Add(Controller.TrafficLightList(6))
        BusStateList.Add(busState1)

        Dim busState2 As New State(Controller.TrafficLightList)
        busState2.Id = 5
        busState2.AffectedTrafficLightList.Add(Controller.TrafficLightList(2))
        busState2.AffectedTrafficLightList.Add(Controller.TrafficLightList(3))
        busState2.AffectedTrafficLightList.Add(Controller.TrafficLightList(6))
        BusStateList.Add(busState2)
    End Sub

    Public Sub StartTrafficLightController(ByVal test As Boolean)
        _test = test

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

        _firstRun = True
        _nonBusStatesPassed = My.Settings.MinimumBusStateDelay + 1

        Dim stopwatch As Stopwatch = stopwatch.StartNew()

        If _test Then
            If _test Then
                Test()
            End If
        End If

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

            Dim i As Integer = 0

            While i <= StateList.Count - 1
                If Thread.VolatileRead(_threadStarted) = 1 Then

                    If _busStateQueued AndAlso _nonBusStatesPassed >= My.Settings.MinimumBusStateDelay Then
                        Dim randomNumber As Integer = Random.Next(2)

                        StateList.Insert(i, BusStateList(randomNumber))
                        _nonBusStatesPassed = 0
                    Else
                        If i <> StateList.Count - 1 Then
                            NextState = StateList(i + 1)
                        Else
                            NextState = StateList(0)
                        End If
                    End If

                    If Not _firstRun Then
                        If Not _previousBusState Then
                            If i <> 0 Then
                                PreviousState = StateList(i - 1)
                            Else
                                PreviousState = StateList(StateList.Count - 1)
                            End If
                        End If

                        _previousBusState = False
                    End If

                    _maxQueue = 0

                    For Each trafficLight In StateList(i).AffectedTrafficLightList
                        If trafficLight.GetVehicleCount() > _maxQueue Then
                            _maxQueue = _maxQueue + trafficLight.GetVehicleCount()
                        End If
                    Next

                    _mainWindow.LogMessage(5, "Longest queue: " + _maxQueue.ToString() + ".")

                    StateList(i).StartState(_mainWindow, _maxQueue)
                End If

                If Thread.VolatileRead(_threadStarted) = 1 Then
                    _mainWindow.LogMessage(5, "Waiting for state " + StateList(i).Id.ToString() + " to finish.")

                    While StateList(i).GetThread() IsNot Nothing AndAlso StateList(i).GetThread().IsAlive
                        If Thread.VolatileRead(_threadStarted) = 0 Then
                            Exit While
                        End If

                        Thread.Sleep(10)
                    End While

                    If Thread.VolatileRead(_threadStarted) = 1 Then

                        If StateList(i).GetThread() IsNot Nothing Then
                            StateList(i).GetThread().Join()
                        End If

                        If StateList(i).Id = 5 Then

                            PreviousState = StateList(i)
                            _previousBusState = True

                            RemoveBus()
                        Else
                            _nonBusStatesPassed = _nonBusStatesPassed + 1
                        End If
                    End If
                End If

                If _previousBusState Then
                    If i <> 0 Then
                        'i = i - 1
                    End If
                Else
                    i = i + 1
                End If

                If _firstRun Then
                    _firstRun = False
                End If

            End While

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

    Public Sub Test()
        SendMessage(New Message(1, New Integer() {2, 3, 0}))
        SendMessage(New Message(1, New Integer() {3, 2, 0}))
        SendMessage(New Message(1, New Integer() {1, 2, 0}))
        SendMessage(New Message(1, New Integer() {2, 1, 0}))
    End Sub

    Private Sub RemoveBus()
        For i As Integer = StateList.Count() - 1 To 0 Step -1

            If StateList(i).Id = 5 Then
                StateList.Remove(StateList(i))
            End If
        Next i

        If Controller.TrafficLightList(6).GetVehicleCount() <> 0 Then
            _busStateQueued = False

        End If

        _mainWindow.LogMessage(5, "Bus state was removed.")
    End Sub

    Public Sub AddBus()

        If Not _busStateQueued Then
            _busStateQueued = True

            _mainWindow.LogMessage(1, "A bus has arrived. Bus state will be executed as soon as possible.")
        Else
            _mainWindow.LogMessage(1, "A bus has arrived, a bus state is already queued.")
        End If
    End Sub

    Public Sub ResetMaxQueue()
        _maxQueue = 0
    End Sub

    Public Sub SetMainWindow(ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
    End Sub

End Module
