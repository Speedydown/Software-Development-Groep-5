Imports System.ComponentModel
Imports System.Threading

Friend Class TrafficLightGroup
    Inherits TrafficLightComponent
    Private ReadOnly _trafficLights As New List(Of TrafficLight)
    Private WithEvents _trafficLightGroupThread As BackgroundWorker

    Public Sub New()
        'Create a new thread.
        _trafficLightGroupThread = New BackgroundWorker
        _trafficLightGroupThread.WorkerSupportsCancellation = True
    End Sub

    Public Overrides Sub SetState(ByVal state As Integer)

        For Each trafficLight As TrafficLight In _trafficLights
            trafficLight.SetState(state)
        Next
    End Sub

    Public Overrides Function GetState() As Integer
        Throw New NotImplementedException()
    End Function

    Public Function Contains(ByVal id As Integer) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Sub AddTrafficLight(ByVal trafficLight As TrafficLight)
        _trafficLights.Add(trafficLight)
    End Sub

    Private Sub TrafficLightGroup(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _trafficLightGroupThread.DoWork
        Do While Not _trafficLightGroupThread.CancellationPending

            Thread.Sleep(3000)


        Loop
    End Sub
End Class
