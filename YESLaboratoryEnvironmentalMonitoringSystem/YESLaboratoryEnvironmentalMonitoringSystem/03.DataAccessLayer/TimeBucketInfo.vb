''' <summary>
''' 时间段设置信息
''' </summary>
Public Structure TimeBucketInfo
    ''' <summary>
    ''' 开始时间(1比30分钟)
    ''' </summary>
    Dim StartTime As Integer

    ''' <summary>
    ''' 温度阈值
    ''' </summary>
    Dim TemperatureThreshold As DetectionInfo
    ''' <summary>
    ''' 湿度阈值
    ''' </summary>
    Dim HumidityThreshold As DetectionInfo
    ''' <summary>
    ''' CO2阈值
    ''' </summary>
    Dim CO2Threshold As DetectionInfo

    'Public WriteOnly Property DataSource As Byte()
    '    Set
    '        StartTime = BitConverter.ToInt16({Value(1), Value(0)}, 0)
    '        TemperatureThreshold.DataSource = {Value(2), Value(3), Value(4)}
    '        HumidityThreshold.DataSource = {Value(5), Value(6), Value(7)}
    '        CO2Threshold.DataSource = {Value(8), Value(9), Value(10)}
    '    End Set
    'End Property

    Public Overrides Function ToString() As String
        Return Wangk.Hash.Bin2Hex({StartTime \ 2, If(StartTime Mod 2, 30, 0)}) &
            TemperatureThreshold.ToString &
            HumidityThreshold.ToString &
            CO2Threshold.ToString
    End Function

End Structure