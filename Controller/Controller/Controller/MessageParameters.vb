Public Class MessageParameters

    'Message types.
    Public Shared ReadOnly VehicleMessage As Byte = 1
    Public Shared ReadOnly TrafficLightMessage As Byte = 2

    'Directions.
    Public Shared ReadOnly North As Byte = 0
    Public Shared ReadOnly East As Byte = 1
    Public Shared ReadOnly South As Byte = 2
    Public Shared ReadOnly West As Byte = 3
    Public Shared ReadOnly VentWeg As Byte = 4

    'Vehicles.
    Public Shared ReadOnly Car As Byte = 0
    Public Shared ReadOnly Bicycle As Byte = 1
    Public Shared ReadOnly Bus As Byte = 2
    Public Shared ReadOnly Walker As Byte = 3

    'Traffic Light states.
    Public Shared ReadOnly Red As Byte = 0
    Public Shared ReadOnly Orange As Byte = 1
    Public Shared ReadOnly Green As Byte = 2

End Class
