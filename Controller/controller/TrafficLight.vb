Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Threading

Class TrafficLight
    Private _queue As New Integer
    Private WithEvents _trafficLightThread As BackgroundWorker
    Private _id As Integer
    Private _state As Integer
    Private ReadOnly _controller As Controller

    Sub New(ByVal controller As Controller)
        _controller = controller

        _trafficLightThread = New BackgroundWorker
        _trafficLightThread.WorkerSupportsCancellation = True
    End Sub

    Public Function GetState() As Integer
        Return _state
    End Function

    Public Sub SetState(ByVal state As Integer)
        _state = state
    End Sub

    Public Sub SetId(ByVal id As Integer)
        _id = id
    End Sub

    Public Function GetId() As Integer
        Return _id
    End Function

    Public Sub AddVehicle()
        _queue = _queue + 1
    End Sub

    Public Sub RemoveVehicle()
        _queue = _queue - 1
    End Sub

    Public Sub ChangeState()
        If Not _trafficLightThread.IsBusy And Not _trafficLightThread.CancellationPending Then
            _trafficLightThread.RunWorkerAsync()
        End If
    End Sub

    Public Function GetVehicleCount() As Integer
        Return _queue
    End Function

    Private Sub ChangeStateWorker(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _trafficLightThread.DoWork

        Thread.Sleep(2000)
        _controller.SendMessage(New Message(2, New Integer() {_id, 0, 0}))

        _trafficLightThread.CancelAsync()
    End Sub
End Class
