''' <summary>
''' 监测值信息
''' </summary>
Public Structure DetectionInfo

    ''' <summary>
    ''' 最大值
    ''' </summary>
    Dim Maximum As Int16

    ''' <summary>
    ''' 超过最大值时继电器是否连通
    ''' </summary>
    Dim IsRelayConnectWhenBeyondTheMaximum As Boolean

    Public Overrides Function ToString() As String
        Return Wangk.Hash.Bin2Hex({Maximum >> 8 And &HFF, Maximum And &HFF, If(IsRelayConnectWhenBeyondTheMaximum, 1, 0)})
    End Function

End Structure