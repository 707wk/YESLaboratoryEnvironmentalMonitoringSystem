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

    Public Overrides Function ToString() As String
        Return Wangk.Hash.Bin2Hex({StartTime \ 2, If(StartTime Mod 2, 30, 0)}) &
            TemperatureThreshold.ToString &
            HumidityThreshold.ToString &
            CO2Threshold.ToString
    End Function

End Structure