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
    ''' <returns></returns>
    Public Shared ReadOnly Property IsOpen As Boolean
        Get
            Return SP.IsOpen
        End Get
    End Property

    ''' <summary>
    ''' 主窗体
    ''' </summary>
    Public Shared UIMainForm As MainForm

#Region "连接串口"
    ''' <summary>
    ''' 连接串口
    ''' </summary>
    Public Shared Sub Connect(SerialPort As String, BPS As Integer)
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
        Dim sendData() = Wangk.Hash.Hex2Bin("aadb01050000")
        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
        Dim CRCBytes = BitConverter.GetBytes(CRC)
        sendData(sendData.Count - 2) = CRCBytes(0)
        sendData(sendData.Count - 1) = CRCBytes(1)

        '发送检测指令
        SP.Write(sendData, 0, sendData.Count)
        '等待数据返回
        Threading.Thread.Sleep(500)
        Dim readData(128 - 1) As Byte
        Dim readCount = SP.Read(readData, 0, 128)

        '判断CRC
        CRC = Wangk.Hash.GetCRC16Modbus(readData, readCount - 2)
        CRCBytes = BitConverter.GetBytes(CRC)
        If readData(readCount - 2) <> CRCBytes(0) OrElse
            readData(readCount - 1) <> CRCBytes(1) Then
            Throw New Exception($"数据校验失败:{Wangk.Hash.Bin2Hex(readData)}")
        End If

        Return {
            BitConverter.ToInt16({readData(1), readData(0)}, 0),
            BitConverter.ToUInt16({readData(3), readData(2)}, 0),
            BitConverter.ToUInt16({readData(5), readData(4)}, 0)
        }
    End Function
#End Region

#Region "回读配置信息"

#End Region

#Region "下发配置信息"

#End Region

#Region "单片机对时"
    ''' <summary>
    ''' 单片机对时
    ''' </summary>
    Public Shared Sub SetMCUDatetime()
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

        '发送检测指令
        SP.Write(sendData, 0, sendData.Count)
        '等待数据返回
        Threading.Thread.Sleep(500)
        Dim readData(128 - 1) As Byte
        Dim readCount = SP.Read(readData, 0, 128)

        '判断CRC
        CRC = Wangk.Hash.GetCRC16Modbus(readData, readCount - 2)
        CRCBytes = BitConverter.GetBytes(CRC)
        If readData(readCount - 2) <> CRCBytes(0) OrElse
            readData(readCount - 1) <> CRCBytes(1) Then
            Throw New Exception($"数据校验失败:{Wangk.Hash.Bin2Hex(readData)}")
        End If

        If readData(readCount) <> &H1A OrElse
            readData(readCount + 1) <> &H1B Then
            Throw New Exception($"对时失败")
        End If

    End Sub
#End Region

End Class
