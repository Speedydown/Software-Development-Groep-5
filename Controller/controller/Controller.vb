Imports System.ComponentModel
Imports System.Threading

Public Class Controller
    Private WithEvents _controllerThread As BackgroundWorker
    Private ReadOnly _server As Server
    Private ReadOnly _mainWindow As MainWindow
    Private _receivedMessage As Message
    Private ReadOnly _trafficLightList As List(Of TrafficLight)

    Public Sub New(ByVal server As Server, ByVal mainWindow As MainWindow)
        _server = server
        _mainWindow = mainWindow

        'Create a new thread.
        _controllerThread = New BackgroundWorker
        _controllerThread.WorkerSupportsCancellation = True
        _trafficLightList = New List(Of TrafficLight)

        'Initialize traffic lights
        Dim trafficLightLeft4 As TrafficLight = New TrafficLight(Me)
        trafficLightLeft4.SetId(4)
        _trafficLightList.Add(trafficLightLeft4)

        Dim trafficLightLeft5 As TrafficLight = New TrafficLight(Me)
        trafficLightLeft5.SetId(5)
        _trafficLightList.Add(trafficLightLeft5)

    End Sub

    Public Sub StartController()

        'Start the controller if it is not already started.
        If Not _controllerThread.IsBusy() And Not _controllerThread.CancellationPending Then
            _controllerThread.RunWorkerAsync()
        Else
            _mainWindow.LogMessage(1, "Controller is already started.")
        End If
    End Sub

    Public Sub StopController()
        'Stop the controller if it started.
        If _controllerThread.IsBusy And Not _controllerThread.CancellationPending Then
            _controllerThread.CancelAsync()
        Else
            _mainWindow.LogMessage(1, "Controller has not been started.")
        End If
    End Sub

    Private Sub Controller(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _controllerThread.DoWork
        Dim spawn As Boolean
        _mainWindow.LogMessage(1, "Controller started.")

        Do While Not _controllerThread.CancellationPending

            If Not spawn Then
                _mainWindow.LogMessage(1, "Waiting 5 seconds for the test vehicle to spawn...")

                Thread.Sleep(5000)
                SendMessage(New Message(1, New Integer() {2, 3, 0}))

                spawn = True
            End If

            If _receivedMessage IsNot Nothing Then
                If _receivedMessage.Type = 1 Then

                End If
                If _receivedMessage.Type = 2 Then

                End If
                If _receivedMessage.Type = 3 Then

                    For Each trafficLight As TrafficLight In _trafficLightList
                        If trafficLight.GetId() = _receivedMessage.Parameters(0) Then

                            If _receivedMessage.Parameters(1) = 1 Then
                                trafficLight.AddVehicle()
                                SendMessage(New Message(2, New Integer() {trafficLight.GetId(), 2, 0}))
                            End If

                            If _receivedMessage.Parameters(1) = 0 Then
                                trafficLight.RemoveVehicle()

                                _mainWindow.LogMessage(1, "Changing state of traffic light " + trafficLight.GetId() + " in 2 seconds.")
                                trafficLight.ChangeState()
                            End If

                        End If
                    Next
                End If

                _receivedMessage = Nothing
            End If

            Thread.Sleep(10)
        Loop

        _mainWindow.LogMessage(1, "Controller stopped.")
    End Sub

    Public Sub ReceiveMessage(ByVal message As Message)
        _receivedMessage = message
    End Sub

    Public Sub SendMessage(ByVal message As Message)
        _server.OutgoingMessage(message)
    End Sub
End Class
