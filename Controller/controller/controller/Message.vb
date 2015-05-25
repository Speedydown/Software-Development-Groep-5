Imports System.Text

Public Class Message
    Private _type As Integer
    Private _parameters As Integer()

    Public Property Type() As Integer
        Get
            Return _type
        End Get
        Set(ByVal value As Integer)
            _type = value
        End Set
    End Property

    Public Property Parameters() As Integer()
        Get
            Return _parameters
        End Get
        Set(ByVal value As Integer())
            _parameters = value
        End Set
    End Property

    Public Sub New(ByVal type As Integer, ByVal parameters As Integer())
        _type = type
        _parameters = parameters
    End Sub

    Public Sub ClearMessage()
        _parameters = Nothing

    End Sub

    Public Function MessageToString() As String

        Dim messageAsString As New StringBuilder

        If _type = 1 Then
            messageAsString.Append("Vehicle message, ")

            Select Case _parameters(0)
                Case 0
                    messageAsString.Append("North, ")
                Case 1
                    messageAsString.Append("East, ")
                Case 2
                    messageAsString.Append("South, ")
                Case 3
                    messageAsString.Append("West, ")
                Case 4
                    messageAsString.Append("Frontage road, ")
                Case Else
                    messageAsString.Append("Unknown, raw: " + _parameters(0).ToString() + ", ")
            End Select

            Select Case _parameters(1)
                Case 0
                    messageAsString.Append("North, ")
                Case 1
                    messageAsString.Append("East, ")
                Case 2
                    messageAsString.Append("South, ")
                Case 3
                    messageAsString.Append("West, ")
                Case 4
                    messageAsString.Append("Frontage road, ")
                Case Else
                    messageAsString.Append("Unknown, raw: " + _parameters(1).ToString() + ", ")
            End Select

            Select Case _parameters(2)
                Case 0
                    messageAsString.Append("Car")
                Case 1
                    messageAsString.Append("Bicycle")
                Case 2
                    messageAsString.Append("Bus")
                Case 3
                    messageAsString.Append("Pedestrian")
                Case Else
                    messageAsString.Append("Unknown, raw: " + _parameters(2).ToString())
            End Select
        End If

        If _type = 2 Then
            messageAsString.Append("Traffic light message, ")
            messageAsString.Append("Traffic light Id: ")

            If (_parameters(0) >= 0 AndAlso _parameters(0) <= 255) Then
                messageAsString.Append(_parameters(0).ToString() + ", ")
            Else
                messageAsString.Append("Unknown, raw:" + _parameters(0).ToString() + ", ")
            End If

            Select Case _parameters(1)
                Case 0
                    messageAsString.Append("Red")
                Case 1
                    messageAsString.Append("Orange")
                Case 2
                    messageAsString.Append("Green")
                Case Else
                    messageAsString.Append("Unknown, raw: " + _parameters(1).ToString())
            End Select
        End If

        If _type = 3 Then
            messageAsString.Append("Vehicle announcement message, ")
            messageAsString.Append("Traffic light ID: ")

            If (_parameters(0) >= 0 AndAlso _parameters(0) <= 255) Then
                messageAsString.Append(_parameters(0).ToString() + ", ")
            Else
                messageAsString.Append("Unknown, raw:" + _parameters(0).ToString() + ", ")
            End If

            messageAsString.Append("Distance: ")

            If (_parameters(1) >= 0 AndAlso _parameters(1) <= 255) Then
                messageAsString.Append(_parameters(1).ToString())
            Else
                messageAsString.Append("Unknown, raw:" + _parameters(1).ToString())
            End If
        End If

        If _type <> 1 AndAlso _type <> 2 AndAlso _type <> 3 Then
            messageAsString.Append("Unknow message, raw: " + _type.ToString())
        End If

        Return messageAsString.ToString()
    End Function


End Class
