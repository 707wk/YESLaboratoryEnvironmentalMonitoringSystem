''' <summary>
''' 全局配置类
''' </summary>
Public Class AppSetting
    ''' <summary>
    ''' 串口号
    ''' </summary>
    Public SerialPort As String
    ''' <summary>
    ''' 波特率
    ''' </summary>
    Public Shared BPS As Integer = 9600

    ''' <summary>
    ''' 设备轮询间隔(ms)
    ''' </summary>
    Public Shared pollingInterval As Integer = 1000



End Class
