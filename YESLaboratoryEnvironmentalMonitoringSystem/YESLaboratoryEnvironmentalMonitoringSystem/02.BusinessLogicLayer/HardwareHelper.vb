''' <summary>
''' 硬件辅助类
''' </summary>
Public NotInheritable Class HardwareHelper
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 串口变量
    ''' </summary>
    Private Shared SP As New IO.Ports.SerialPort

    ''' <summary>
    ''' 是否连接串口
    ''' </summary>
    Public Shared ReadOnly Property IsOpen As Boolean
        Get
            Return SP.IsOpen
        End Get
    End Property

#Region "连接串口"
    ''' <summary>
    ''' 连接串口
    ''' </summary>
    Public Shared Sub Connect(SerialPort As String, BPS As Integer)
        If SP.IsOpen Then
            Exit Sub
        End If

        With SP
            .PortName = SerialPort
            .BaudRate = BPS
            .Parity = IO.Ports.Parity.None
            .DataBits = 8
            .StopBits = 1
            .ReadTimeout = 500
            .WriteTimeout = 500
        End With

        SP.Open()

    End Sub
#End Region

#Region "断开串口"
    ''' <summary>
    ''' 断开串口
    ''' </summary>
    Public Shared Sub DisConnect()
        If Not SP.IsOpen Then
            Exit Sub
        End If

        Try
            SP.Close()
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "读取传感器监测值"
    ''' <summary>
    ''' 读取传感器监测值
    ''' </summary>
    Public Shared Function GetSensorData() As Integer()
        If Not SP.IsOpen Then
            Throw New Exception("串口未连接")
        End If

        SP.DiscardInBuffer()

        Dim sendData() = Wangk.Hash.Hex2Bin("aadb01050000")
        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
        Dim CRCBytes = BitConverter.GetBytes(CRC)
        sendData(sendData.Count - 2) = CRCBytes(0)
        sendData(sendData.Count - 1) = CRCBytes(1)

        '发送指令
        SP.Write(sendData, 0, sendData.Count)
        '等待数据返回
        Threading.Thread.Sleep(1000)
        Dim readData(128 - 1) As Byte
        Dim readCount = SP.Read(readData, 0, 128)

        If readCount < 6 Then
            Throw New Exception($"数据接收不完整:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

        '判断CRC
        CRC = Wangk.Hash.GetCRC16Modbus(readData, readCount - 2)
        CRCBytes = BitConverter.GetBytes(CRC)
        If readData(readCount - 2) <> CRCBytes(0) OrElse
            readData(readCount - 1) <> CRCBytes(1) Then
            Throw New Exception($"数据校验失败:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

        Return {
            BitConverter.ToInt16({readData(1), readData(0)}, 0),
            BitConverter.ToInt16({readData(3), readData(2)}, 0),
            BitConverter.ToUInt16({readData(5), readData(4)}, 0)
        }

    End Function
#End Region

#Region "回读配置信息"
    ''' <summary>
    ''' 回读配置信息
    ''' </summary>
    Public Shared Sub GetTimeBucket()
        If Not SP.IsOpen Then
            Throw New Exception("串口未连接")
        End If

        SP.DiscardInBuffer()

        Dim sendData() = Wangk.Hash.Hex2Bin("aadb01030000")
        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
        Dim CRCBytes = BitConverter.GetBytes(CRC)
        sendData(sendData.Count - 2) = CRCBytes(0)
        sendData(sendData.Count - 1) = CRCBytes(1)

        'MsgBox(Wangk.Hash.Bin2Hex(sendData))

        '发送指令
        SP.Write(sendData, 0, sendData.Count)
        '等待数据返回
        Threading.Thread.Sleep(2000)
        Dim readData(128 - 1) As Byte
        Dim readCount = SP.Read(readData, 0, 128)

        If readCount < 11 Then
            Throw New Exception($"数据接收不完整:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

        '判断CRC
        CRC = Wangk.Hash.GetCRC16Modbus(readData, readCount - 2)
        CRCBytes = BitConverter.GetBytes(CRC)
        If readData(readCount - 2) <> CRCBytes(0) OrElse
            readData(readCount - 1) <> CRCBytes(1) Then
            Throw New Exception($"数据校验失败:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

        With AppSettingHelper.GetInstance.DefaultTimeBucket
            .TemperatureThreshold.Maximum = BitConverter.ToInt16({readData(1), readData(0)}, 0)
            .TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum = If(readData(2) = 1, True, False)
            .HumidityThreshold.Maximum = BitConverter.ToInt16({readData(4), readData(3)}, 0)
            .HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum = If(readData(5) = 1, True, False)
            .CO2Threshold.Maximum = BitConverter.ToInt16({readData(7), readData(6)}, 0)
            .CO2Threshold.IsRelayConnectWhenBeyondTheMaximum = If(readData(8) = 1, True, False)
        End With

        AppSettingHelper.GetInstance.OtherTimeBucketItems.Clear()
        For i001 = 0 To readData(9) - 1
            Dim addTimeBucket = New TimeBucketInfo
            Dim tmpID = 10 + i001 * 11

            addTimeBucket.StartTime = readData(tmpID + 0) * 2 + (readData(tmpID + 1) Mod 30) 'BitConverter.ToInt16({readData(tmpID + 1), readData(tmpID + 0)}, 0)
            addTimeBucket.TemperatureThreshold.Maximum = BitConverter.ToInt16({readData(tmpID + 3), readData(tmpID + 2)}, 0)
            addTimeBucket.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum = If(readData(tmpID + 4) = 1, True, False)
            addTimeBucket.HumidityThreshold.Maximum = BitConverter.ToInt16({readData(tmpID + 6), readData(tmpID + 5)}, 0)
            addTimeBucket.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum = If(readData(tmpID + 7) = 1, True, False)
            addTimeBucket.CO2Threshold.Maximum = BitConverter.ToInt16({readData(tmpID + 9), readData(tmpID + 8)}, 0)
            addTimeBucket.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum = If(readData(tmpID + 10) = 1, True, False)

            AppSettingHelper.GetInstance.OtherTimeBucketItems.Add(addTimeBucket)
        Next

    End Sub
#End Region

#Region "下发配置信息"
    ''' <summary>
    ''' 下发配置信息
    ''' </summary>
    Public Shared Sub SetTimeBucket()
        If Not SP.IsOpen Then
            Throw New Exception("串口未连接")
        End If

        SP.DiscardInBuffer()

        Dim tmpStr = "aadb" & AppSettingHelper.GetInstance.DefaultTimeBucket.ToString & "00"
        For Each item In AppSettingHelper.GetInstance.OtherTimeBucketItems
            tmpStr += item.ToString
        Next
        tmpStr += "0000"
        Dim sendData() = Wangk.Hash.Hex2Bin(tmpStr)

        sendData(2) = &H1
        sendData(3) = &H4
        sendData(13) = AppSettingHelper.GetInstance.OtherTimeBucketItems.Count

        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
        Dim CRCBytes = BitConverter.GetBytes(CRC)
        sendData(sendData.Count - 2) = CRCBytes(0)
        sendData(sendData.Count - 1) = CRCBytes(1)

        'MsgBox(Wangk.Hash.Bin2Hex(sendData))

        '发送指令
        SP.Write(sendData, 0, sendData.Count)
        '等待数据返回
        Threading.Thread.Sleep(2000)
        Dim readData(128 - 1) As Byte
        Dim readCount = SP.Read(readData, 0, 128)

        If readCount < 2 Then
            Throw New Exception($"数据接收不完整:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

        '判断CRC
        'CRC = Wangk.Hash.GetCRC16Modbus(readData, readCount - 2)
        'CRCBytes = BitConverter.GetBytes(CRC)
        'If readData(readCount - 2) <> CRCBytes(0) OrElse
        '    readData(readCount - 1) <> CRCBytes(1) Then
        '    Throw New Exception($"数据校验失败:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        'End If

        If readData(0) <> &H1A OrElse
            readData(0 + 1) <> &H1B Then
            Throw New Exception($"下发失败:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

    End Sub
#End Region

#Region "单片机对时"
    ''' <summary>
    ''' 单片机对时
    ''' </summary>
    Public Shared Sub SetMCUDatetime()
        If Not SP.IsOpen Then
            Throw New Exception("串口未连接")
        End If

        SP.DiscardInBuffer()

        Dim sendData() = Wangk.Hash.Hex2Bin("aadb0106000000000000000000")

        sendData(4) = Now.Year \ &H100
        sendData(5) = Now.Year Mod &H100
        sendData(6) = Now.Month
        sendData(7) = Now.Day
        sendData(8) = Now.Hour
        sendData(9) = Now.Minute
        sendData(10) = Now.Second

        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
        Dim CRCBytes = BitConverter.GetBytes(CRC)
        sendData(sendData.Count - 2) = CRCBytes(0)
        sendData(sendData.Count - 1) = CRCBytes(1)
        Debug.WriteLine(Wangk.Hash.Bin2Hex(sendData))
        '发送指令
        SP.Write(sendData, 0, sendData.Count)
        '等待数据返回
        Threading.Thread.Sleep(2000)
        Dim readData(128 - 1) As Byte
        Dim readCount = SP.Read(readData, 0, 128)

        If readCount < 2 Then
            Throw New Exception($"数据接收不完整:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

        '判断CRC
        'CRC = Wangk.Hash.GetCRC16Modbus(readData, readCount - 2)
        'CRCBytes = BitConverter.GetBytes(CRC)
        'If readData(readCount - 2) <> CRCBytes(0) OrElse
        '    readData(readCount - 1) <> CRCBytes(1) Then
        '    Throw New Exception($"数据校验失败:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        'End If

        If readData(0) <> &H1A OrElse
            readData(0 + 1) <> &H1B Then
            Throw New Exception($"对时失败:{Wangk.Hash.Bin2Hex(readData, readCount)}[{readCount}]")
        End If

    End Sub
#End Region

End Class
