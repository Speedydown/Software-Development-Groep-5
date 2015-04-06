Friend Class TrafficLight
    Inherits TrafficLightComponent
    Private ReadOnly _queue As New List(Of Vehicle)

    Private _id As Integer
    Private _state As Integer

    Public Overrides Function GetState() As Integer
        Return _state
    End Function

    Public Overrides Sub SetState(state As Integer)
        _state = state
    End Sub

    Public Sub SetId(id As Integer)
        _id = id
    End Sub

    Public Function GetId() As Integer
        Return _id
    End Function

    Public Sub AddVehicle(ByVal vehicle As Vehicle)
        _queue.Add(vehicle)
    End Sub
End Class
