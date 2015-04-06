Imports System.ComponentModel
Imports System.Threading

Public Class Controller
    Private WithEvents _controllerThread As BackgroundWorker
    Private ReadOnly _server As Server
    Private ReadOnly _mainWindow As MainWindow
    Private _receivedMessage As Byte()
    Private Shared ReadOnly Random As New Random(DateTime.UtcNow.Millisecond)

    Public Sub New(ByVal server As Server, ByVal mainWindow As MainWindow)
        _server = server
        _mainWindow = mainWindow

        'Create a new thread.
        _controllerThread = New BackgroundWorker
        _controllerThread.WorkerSupportsCancellation = True

        'Initialize traffic lights
        Dim trafficLightLeft4 As TrafficLight = New TrafficLight()
        Dim trafficLightGroup1 As TrafficLightGroup = New TrafficLightGroup()
        trafficLightGroup1.AddTrafficLight(trafficLightLeft4)
    End Sub

    Public Sub StartController()

        'Start the controller if it is not already started.
        If Not _controllerThread.IsBusy() And Not _controllerThread.CancellationPending Then
            _controllerThread.RunWorkerAsync()
            _mainWindow.LogMessage("Controller started.")
        Else
            _mainWindow.LogMessage("Controller is already started.")
        End If
    End Sub

    Public Sub StopController()
        'Stop the controller if it started.
        If _controllerThread.IsBusy And Not _controllerThread.CancellationPending Then
            _controllerThread.CancelAsync()
            _mainWindow.LogMessage("Controller stopped.")
        Else
            _mainWindow.LogMessage("Controller has not been started.")
        End If
    End Sub

    Private Sub Controller(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _controllerThread.DoWork

        Dim first As Boolean = False
        Dim second As Boolean = False
        Dim secondMessage() As Byte = {3, 4, 1, 0}
        Dim third As Boolean = False
        Dim thirdMessage() As Byte = {3, 4, 0, 0}


        Do While Not _controllerThread.CancellationPending
            'TODO Controller routines here.

            If Not second Then
                If Not first Then
                    'Controller stuurt voertuig packet (0x01) 
                    SendMessage(New Byte() {1, 2, 3, 0})
                    first = True
                End If

                If first Then
                    'Block until the message is received.
                    While Not second

                        If _receivedMessage IsNot Nothing Then
                            If _receivedMessage.Equals(secondMessage) Then
                                'De controller zal daarna het stoplicht op groen doen
                                SendMessage(New Byte() {2, 4, 2, 0})

                                second = True
                            End If
                        End If

                        Thread.Sleep(10)
                    End While

                End If
            End If
            If second Then
                'Block until the message is received.
                While Not third

                    If _receivedMessage IsNot Nothing Then
                        If _receivedMessage.Equals(thirdMessage) Then
                            'Na een x aantal seconden zal dit stoplicht (en misschien anderen) ook weer op rood gaan
                            SendMessage(New Byte() {2, 4, 0, 0})

                            third = True
                        End If
                    End If
                    Thread.Sleep(10)

                End While
            End If

            Thread.Sleep(10)

            ''TESTING (SEND A RANDOM MESSAGE EVERY THREE SECONDS)
            ''Generates a random message.
            'Dim randomMessage = Random.Next(0, 2)

            'Dim numbers As Byte()

            'If randomMessage = 0 Then
            '    numbers = New Byte() {1, Random.Next(0, 5), Random.Next(0, 5), Random.Next(0, 4)}
            'End If
            'If randomMessage = 1 Then
            '    numbers = New Byte() {2, Random.Next(0, 256), Random.Next(0, 3)}
            'End If

            'SendMessage(numbers)
        Loop
    End Sub

    Public Sub ReceiveMessage(ByVal message As Byte())
        _receivedMessage = message
    End Sub

    Private Sub SendMessage(ByVal message As Byte())
        _server.OutgoingMessage(message)
    End Sub
End Class
