Imports System.Text

Public Class Message
    'Public Function EncodeMessage(ByVal parameters As Byte()) As String
    '    Dim builder As New StringBuilder()

    '    For Each value As Byte In parameters
    '        builder.Append(value)
    '    Next value

    '    Return builder.ToString()
    'End Function

    'Public Function DecodeMessage(message As Byte()) As Byte()

    'End Function

    Public Function MessageToString(ByVal message As Byte()) As String

        Dim messageAsString As New StringBuilder

        If message(0) = 1 Then
            messageAsString.Append("Vehicle message, ")

            Select Case message(1)
                Case 0
                    messageAsString.Append("Noord, ")
                Case 1
                    messageAsString.Append("Oost, ")
                Case 2
                    messageAsString.Append("Zuid, ")
                Case 3
                    messageAsString.Append("West, ")
                Case 4
                    messageAsString.Append("Ventweg, ")
                Case Else
                    messageAsString.Append("Unknown, raw: " + message(1).ToString() + ", ")
            End Select

            Select Case message(2)
                Case 0
                    messageAsString.Append("Noord, ")
                Case 1
                    messageAsString.Append("Oost, ")
                Case 2
                    messageAsString.Append("Zuid, ")
                Case 3
                    messageAsString.Append("West, ")
                Case 4
                    messageAsString.Append("Ventweg, ")
                Case Else
                    messageAsString.Append("Unknown, raw: " + message(2).ToString() + ", ")
            End Select

            Select Case message(3)
                Case 0
                    messageAsString.Append("Auto")
                Case 1
                    messageAsString.Append("Fiets")
                Case 2
                    messageAsString.Append("Bus")
                Case 3
                    messageAsString.Append("Voetganger")
                Case Else
                    messageAsString.Append("Unknown, raw: " + message(3))
            End Select
        End If

        If message(0) = 2 Then
            messageAsString.Append("Traffic Light message, ")
            messageAsString.Append("Stoplicht Id: " + message(1).ToString + ", ")

            Select Case message(2)
                Case 0
                    messageAsString.Append("Red")
                Case 1
                    messageAsString.Append("Orange")
                Case 2
                    messageAsString.Append("Green")
                Case Else
                    messageAsString.Append("Unknown, raw: " + message(2).ToString())
            End Select
        End If

        If message(0) = 3 Then
            messageAsString.Append("Vehicle announcement message, ")
            messageAsString.Append("Traffic Light Id: " + message(1).ToString + ", ")
            messageAsString.Append("Distance: " + message(1).ToString + ", ")
        End If

        If message(0) <> 1 AndAlso message(0) <> 2 AndAlso message(0) <> 3 Then
            messageAsString.Append("Unknow message, raw: " + message(0).ToString())
        End If

        Return messageAsString.ToString()
    End Function
End Class
