Public MustInherit Class Vehicle
    Private ReadOnly _startDirection As Integer
    Private ReadOnly _endDirection As Integer

    Public Sub New(startDirection As Integer, endDirection As Integer)
        _startDirection = startDirection
        _endDirection = endDirection
    End Sub

    Public Function GetStartDirection() As Integer
        Return _startDirection
    End Function

    Public Function GetEndDirection() As Integer
        Return _endDirection
    End Function

End Class
