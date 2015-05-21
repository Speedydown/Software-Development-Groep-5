Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Threading

Public Class TrafficLight
    Public Property State As Integer
    Public Property Sequence As Integer
    Public Property Id As Integer
    Public Property Type As Integer
    Private _queue As New Integer

    Sub New(ByVal id As Integer, ByVal type As Integer)
        Me.Id = id
        Me.Type = type
    End Sub

    Public Sub AddVehicle()
        _queue = _queue + 1

        Console.WriteLine()
    End Sub

    Public Sub RemoveVehicle()
        _queue = _queue - 1
    End Sub

    Public Function GetVehicleCount() As Integer
        Return _queue
    End Function

    Public Sub ResetVehicleCount()
        _queue = 0
    End Sub

    Public Sub ChangeStateToGreen()
        Controller.SendMessage(New Message(2, New Integer() {Id, 2, 0}))
        State = 2
    End Sub

    Public Sub ChangeStateToOrange()
        Controller.SendMessage(New Message(2, New Integer() {Id, 1, 0}))
        State = 1
    End Sub

    Public Sub ChangeStateToRed()
        Controller.SendMessage(New Message(2, New Integer() {Id, 0, 0}))
        State = 0
    End Sub
End Class
