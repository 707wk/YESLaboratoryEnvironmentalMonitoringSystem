Public Class TimeBucketControl

    Public Property DataSource As TimeBucketInfo
        Get
            Return New TimeBucketInfo With {
            .StartTime = TrackBar1.Value,
            .TemperatureThreshold = New DetectionInfo With {
            .Maximum = NumericUpDown1.Value * 10,
            .IsRelayConnectWhenBeyondTheMaximum = SwitchButton1.Value},
            .HumidityThreshold = New DetectionInfo With {
            .Maximum = NumericUpDown2.Value * 10,
            .IsRelayConnectWhenBeyondTheMaximum = SwitchButton2.Value},
            .CO2Threshold = New DetectionInfo With {
            .Maximum = NumericUpDown3.Value,
            .IsRelayConnectWhenBeyondTheMaximum = SwitchButton3.Value}
            }
        End Get
        Set
            TrackBar1.Value = Value.StartTime
            NumericUpDown1.Value = Value.TemperatureThreshold.Maximum / 10
            SwitchButton1.Value = Value.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum

            NumericUpDown2.Value = Value.HumidityThreshold.Maximum / 10
            SwitchButton2.Value = Value.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum

            NumericUpDown3.Value = Value.CO2Threshold.Maximum
            SwitchButton3.Value = Value.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum
        End Set
    End Property

    Public UIMainForm As MainForm

    Public Property StartTime As Integer
        Get
            Return TrackBar1.Value
        End Get
        Set(value As Integer)
            TrackBar1.Value = value
        End Set
    End Property
    Public StopTime As Integer

    Private Sub TimeBucketControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DoubleBuffered = True

    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Label1.Text = $"开始 : {(TrackBar1.Value \ 2):d2}:{If(TrackBar1.Value Mod 2, 30, 0):d2}"

        UIMainForm.CheckTime()

    End Sub

    Public Sub UpdateTimeCount()
        Dim changeX As Integer = 15 + 434 * StartTime / TrackBar1.Maximum
        Dim changeWidth As Integer = 434 * (StopTime - StartTime) / TrackBar1.Maximum

        Panel3.Location = New Point(changeX, Panel3.Location.Y)
        Panel3.Width = changeWidth

        Label2.Text = $"时长 : {((StopTime - StartTime) \ 2):d2}:{If((StopTime - StartTime) Mod 2, 30, 0):d2}"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UIMainForm.RemoveChild(Me)
    End Sub

    '屏蔽鼠标滚轮事件
    Private Sub TrackBar1_MouseWheel(sender As Object, e As MouseEventArgs) Handles TrackBar1.MouseWheel
        Dim tmp As HandledMouseEventArgs = e
        If tmp IsNot Nothing Then tmp.Handled = True
    End Sub
End Class
