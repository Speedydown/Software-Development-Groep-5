﻿Imports System.ComponentModel
Imports System.Threading
Imports System.Threading.Tasks

Public Module Controller
    Private WithEvents _controllerThread As Thread
    Public Property TrafficLightList As List(Of TrafficLight)
    Private _receivedMessage As Message
    Private _threadStarted As Byte
    Private _mainWindow As MainWindow

    Sub New()
        TrafficLightList = New List(Of TrafficLight)()
        Dim walkerCyclistTrafficLightArray = New Integer() {46, 50, 15, 16, 43, 47, 35, 34, 36, 37, 38, 32, 48, 30, 25, 49, 26, 27, 17, 18, 19, 20, 23, 39, 24, 21, 22, 40}
        Dim busTrafficLightArray = New Integer() {6, 13, 14}

        For i As Integer = 0 To 50
            If walkerCyclistTrafficLightArray.Contains(i) Then
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

    Private Sub ControllerWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        Thread.Sleep(2000)

        _mainWindow.LogMessage(1, "Controller started.")

        If My.Settings.StartTrafficLichtsRed Then
            _mainWindow.LogMessage(1, "Setting all traffic lights to red.")

            For Each trafficLicht In TrafficLightList
                trafficLicht.ChangeStateToRed()
                Thread.Sleep(100)
            Next
        End If

        Do While Thread.VolatileRead(_threadStarted) = 1
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
                                trafficLight.AddVehicle()

                                If trafficLight.Id = 6 Then
                                    'TrafficLightController.AddBus()
                                End If
                            End If

                            If _receivedMessage.Parameters(1) = 0 Then
                                trafficLight.RemoveVehicle()
                            End If

                        End If
                    Next
                End If

                _receivedMessage = Nothing
            End If

            Thread.Sleep(10)
        Loop

        If TrafficLightController.CheckTrafficLightControllerStarted() Then
            _mainWindow.LogMessage(1, "Stopping Traffic Light controller.")

            TrafficLightController.StopTrafficLightController()

            If TrafficLightController.GetThread() IsNot Nothing Then
                If TrafficLightController.GetThread().IsAlive Then
                    TrafficLightController.GetThread.Join()
                End If
            End If
        End If

        _mainWindow.LogMessage(1, "Controller stopped.")
        _controllerThread = Nothing
    End Sub

    Public Sub ReceiveMessage(ByVal message As Message)
        _receivedMessage = message
    End Sub

    Public Sub SendMessage(ByVal message As Message)
        Server.OutgoingMessage(message)
    End Sub

    Public Function CheckControllerStarted() As Boolean

        If _controllerThread IsNot Nothing Then
            If _controllerThread.IsAlive Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Function GetThread() As Thread
        Return _controllerThread
    End Function

    Public Sub StartTest()

        If Not TrafficLightController.CheckTrafficLightControllerStarted() Then
            TrafficLightController.StartTrafficLightController(True)
        End If
    End Sub

    Public Sub SetMainWindow(ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
    End Sub

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