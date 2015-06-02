Imports System.ComponentModel
Imports System.Threading
Imports System.Threading.Tasks

'Executes a test loop.
Public Module TestController
    Private WithEvents _testControllerThread As Thread
    Private _mainWindow As MainWindow
    Private _threadStarted As Byte
    Public Property SpawnCars As Boolean
    Public Property SpawnBuses As Boolean
    Public Property SpawnCyclists As Boolean
    Public Property SpawnPedestrians As Boolean
    Public Property TestSpeed As Integer
    ReadOnly RandomInterval As New Random()
    ReadOnly RandomNumber As New Random()

    Public Sub StartTestController()
        If _testControllerThread Is Nothing Then
            'Create a new thread.
            _testControllerThread = New Thread(AddressOf TestControllerWorker)
            _testControllerThread.IsBackground = True
            _testControllerThread.Start()
        Else
            _mainWindow.LogMessage(1, "Test Controller is already started.")
        End If
    End Sub

    Public Sub StopTestController()
        'Stop the Test Controller if it started.
        If _testControllerThread IsNot Nothing AndAlso _testControllerThread.IsAlive() Then
            Thread.VolatileWrite(_threadStarted, 0)
        Else
            _mainWindow.LogMessage(1, "Test Controller has not been started.")
        End If
    End Sub

    'Thread worker
    Private Sub TestControllerWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        _mainWindow.LogMessage(1, "Test Controller started.")

        Dim stopwatch As Stopwatch = stopwatch.StartNew()

        Dim testInterval As Integer
        Dim falseTest As Boolean

        While Thread.VolatileRead(_threadStarted) = 1
            stopwatch.Reset()
            stopwatch.Start()
            Do
                'Get the test speed.
                If TestSpeed = 0 Then
                    testInterval = RandomInterval.Next(1, 4)
                End If
                If TestSpeed = 1 Then
                    testInterval = RandomInterval.Next(0, 5)
                End If
                If TestSpeed = 2 Then
                    testInterval = RandomInterval.Next(0, 2)
                End If
                If TestSpeed = 3 Then
                    testInterval = 0
                End If

                If Thread.VolatileRead(_threadStarted) = 0 Then
                    Exit Do
                End If
                If Not falseTest Then
                    If stopwatch.ElapsedMilliseconds >= (testInterval * 1000) Then
                        If Not Test() Then
                            falseTest = True
                        Else
                            falseTest = False
                        End If
                        Exit Do
                    End If
                Else
                    If Not Test() Then
                        falseTest = True
                    Else
                        falseTest = False
                    End If
                End If


                Thread.Sleep(100)
            Loop
            stopwatch.Stop()

        End While

        _mainWindow.LogMessage(1, "Test Controller stopped.")
        _testControllerThread = Nothing
    End Sub

    'Get the thread object.
    Public Function GetThread() As Thread
        Return _testControllerThread
    End Function

    'Check if the Test Controller is started.
    Public Function CheckTestControllerStarted() As Boolean
        If _testControllerThread IsNot Nothing Then
            If _testControllerThread.IsAlive() Then
                Return True
            End If
        End If

        Return False
    End Function

    'Generate en send a test message.
    Public Function Test() As Boolean

        Dim vehicleTypeList As New List(Of Integer)
        vehicleTypeList.Add(0)
        vehicleTypeList.Add(1)
        vehicleTypeList.Add(2)
        vehicleTypeList.Add(3)

        'Check if vehicle types are excluded.
        If Not SpawnCars Then
            vehicleTypeList.Remove(0)
        End If
        If Not SpawnCyclists Then
            vehicleTypeList.Remove(1)
        End If
        If Not SpawnBuses Then
            vehicleTypeList.Remove(2)
        End If
        If Not SpawnPedestrians Then
            vehicleTypeList.Remove(3)
        End If

        Dim directionStart As Integer = RandomNumber.Next(0, 5)
        Dim directionEnd As Integer = GenerateDirection(directionStart)
        Dim vehicleTypeDouble As Double = RandomNumber.NextDouble() * (1.0 - 0.0) + 0.0

        Dim vehicleType As Integer

        'Generate a vehicle type based on probability.
        If (vehicleTypeDouble <= 0.05) Then
            If vehicleTypeList.Contains(2) Then
                vehicleType = 2
            End If
        Else
            If (vehicleTypeDouble <= 0.2) Then
                If vehicleTypeList.Contains(3) Then
                    vehicleType = 3
                End If
            Else
                If (vehicleTypeDouble <= 0.7) Then
                    If vehicleTypeList.Contains(0) Then
                        vehicleType = 0
                    End If
                Else
                    If vehicleTypeList.Contains(1) Then
                        vehicleType = 1
                    End If
                End If
            End If
        End If


        'Sends the test message if the vehicle type is not excluded.
        If vehicleTypeList.Contains(vehicleType) Then
            SendMessage(New Message(1, New Integer() {directionStart, directionEnd, vehicleType}))
            Return True
        Else
            Return False
        End If

    End Function

    'Generate a end direction and check if the start/end direction are the same.
    Public Function GenerateDirection(previous As Integer) As Integer

        Dim directionEnd As Integer = RandomNumber.Next(0, 5)

        While directionEnd = previous
            directionEnd = RandomNumber.Next(0, 5)
        End While

        Return directionEnd
    End Function

    'Set an reference to the main window.
    Public Sub SetMainWindow(ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
    End Sub

End Module
