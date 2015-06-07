Imports System.ComponentModel
Imports System.Threading
Imports System.Threading.Tasks

'Set the traffic light lists and handles incoming messsages.
Public Module Controller
    Private WithEvents _controllerThread As Thread
    Public Property TrafficLightList As List(Of TrafficLight)
    Private _receivedMessage As Message
    Private _threadStarted As Byte
    Private _mainWindow As MainWindow

    Sub New()
        'Fill the traffic light list.
        TrafficLightList = New List(Of TrafficLight)()
        Dim pedestrianCyclistTrafficLightArray = New Integer() {46, 50, 15, 16, 43, 47, 35, 34, 36, 37, 38, 32, 48, 30, 25, 49, 26, 27, 17, 18, 19, 20, 23, 39, 24, 21, 22, 40}
        Dim busTrafficLightArray = New Integer() {6, 13, 14}

        For i As Integer = 0 To 50
            If pedestrianCyclistTrafficLightArray.Contains(i) Then
                TrafficLightList.Add(New TrafficLight(i, 2))
            Else
                If busTrafficLightArray.Contains(i) Then
                    TrafficLightList.Add(New TrafficLight(i, 3))
                Else
                    TrafficLightList.Add(New TrafficLight(i, 1))
                End If
            End If
        Next i

    End Sub

    Public Sub StartController()
        If _controllerThread Is Nothing Then
            'Create a new thread.
            _controllerThread = New Thread(AddressOf ControllerWorker)
            _controllerThread.IsBackground = True

            _controllerThread.Start()
        Else
            _mainWindow.LogMessage(1, "Controller is already started.")

        End If
    End Sub

    Public Sub StopController()
        'Stop the controller if it started.
        If _controllerThread IsNot Nothing AndAlso _controllerThread.IsAlive() Then
            Thread.VolatileWrite(_threadStarted, 0)

            _mainWindow.LogMessage(5, "Resetting all queues.")
            ResetQueue(Nothing)
        Else
            _mainWindow.LogMessage(1, "Controller has not been started.")
        End If
    End Sub

    'Thread worker.
    Private Sub ControllerWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        Thread.Sleep(2000)

        _mainWindow.LogMessage(1, "Controller started.")

        'Change all traffic lights to red.
        If My.Settings.StartTrafficLichtsRed Then
            _mainWindow.LogMessage(1, "Setting all traffic lights to red.")

            Parallel.ForEach(_TrafficLightList, Sub(trafficLight)
                                                    If trafficLight.Id <> 28 AndAlso trafficLight.Id <> 29 AndAlso trafficLight.Id <> 31 AndAlso trafficLight.Id <> 33 AndAlso trafficLight.Id <> 41 AndAlso trafficLight.Id <> 42 AndAlso trafficLight.Id <> 44 AndAlso trafficLight.Id <> 45 Then
                                                        trafficLight.ChangeStateToRed()
                                                    End If
                                                End Sub)
        End If

        Do While Thread.VolatileRead(_threadStarted) = 1
            'Perform an action based on the incoming message.
            If _receivedMessage IsNot Nothing Then
                If _receivedMessage.Type = 1 Then

                End If
                If _receivedMessage.Type = 2 Then

                End If
                If _receivedMessage.Type = 3 Then

                    For Each trafficLight As TrafficLight In TrafficLightList
                        If trafficLight.Id = _receivedMessage.Parameters(0) Then

                            If Not FirstAnnouncement Then
                                FirstAnnouncement = 1
                            End If

                            If _receivedMessage.Parameters(1) = 1 Then
                                'Add a vehicle to the traffic light.
                                trafficLight.AddVehicle()
                            End If

                            If _receivedMessage.Parameters(1) = 0 Then
                                'Remove a vehicle from the traffic light.
                                trafficLight.RemoveVehicle()
                            End If

                        End If
                    Next
                End If

                _receivedMessage = Nothing
            End If

            'Sleep so the CPU doesn't lock up.
            Thread.Sleep(10)
        Loop

        'Stop the Traffic Light Controller when the controller stops.
        If TrafficLightController.CheckTrafficLightControllerStarted() Then
            _mainWindow.LogMessage(1, "Stopping Traffic Light controller.")

            TrafficLightController.StopTrafficLightController()

            If TrafficLightController.GetThread() IsNot Nothing Then

                'Wait for the Traffic Light Controller to stop.
                If TrafficLightController.GetThread().IsAlive Then
                    TrafficLightController.GetThread.Join()
                End If
            End If
        End If

        _mainWindow.LogMessage(1, "Controller stopped.")
        _controllerThread = Nothing
    End Sub

    'Set the received message.
    Public Sub ReceiveMessage(ByVal message As Message)
        _receivedMessage = message
    End Sub

    'Pass a message to the simulator.
    Public Sub SendMessage(ByVal message As Message)
        Server.OutgoingMessage(message)
    End Sub

    'Check if the controller is started.
    Public Function CheckControllerStarted() As Boolean
        If _controllerThread IsNot Nothing Then
            If _controllerThread.IsAlive Then
                Return True
            End If
        End If

        Return False
    End Function

    'Get the thread object.
    Public Function GetThread() As Thread
        Return _controllerThread
    End Function

    'Set an reference to the main window.
    Public Sub SetMainWindow(ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
    End Sub

    'Reset a (or all) traffic light queue(s).
    Public Sub ResetQueue(ByVal id As Integer)
        For Each trafficLight In TrafficLightList

            If id = Nothing Then
                trafficLight.ResetVehicleCount()
            Else
                If id = trafficLight.Id Then
                    trafficLight.ResetVehicleCount()
                End If
            End If
        Next
    End Sub
End Module
