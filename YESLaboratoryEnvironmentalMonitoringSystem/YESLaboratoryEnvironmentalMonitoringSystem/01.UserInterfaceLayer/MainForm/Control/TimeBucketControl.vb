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

    'Private LastMin As Integer = 0

    'Private _startTime As Integer

    Public Property StartTime As Integer
        Get
            Return TrackBar1.Value
        End Get
        Set(value As Integer)
            TrackBar1.Value = value
        End Set
    End Property
    Public StopTime As Integer

    'Private Sub RangeSlider1_ValueChanged(sender As Object, e As EventArgs)
    '    Label1.Text = $"起始 : {(RangeSlider1.Value.Min \ 2):d2}:{If(RangeSlider1.Value.Min Mod 2, 30, 0):d2}"
    '    Label2.Text = $"终止 : {(RangeSlider1.Value.Max \ 2):d2}:{If(RangeSlider1.Value.Max Mod 2, 30, 0):d2}"
    '    StartTime = RangeSlider1.Value.Min
    '    StopTime = RangeSlider1.Value.Max
    'End Sub

    'Private Sub RangeSlider1_MouseUp(sender As Object, e As MouseEventArgs)
    '    'If LastMin = RangeSlider1.Value.Min Then
    '    '    Exit Sub
    '    'End If

    '    'LastMin = RangeSlider1.Value.Min
    '    'UIMainForm.SortFlowLayoutPanel()

    'End Sub

    'Public Sub IsOK(value As Boolean)
    '    Panel3.BackColor = If(value, Color.FromArgb(18, 150, 219), Color.FromArgb(221, 101, 114))
    'End Sub

    Private Sub TimeBucketControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        'RangeSlider1_ValueChanged(Nothing, Nothing)
        Me.DoubleBuffered = True

        'TrackBar1.DataBindings.Add(New Binding("Value", DataSource, "StartTime", False, DataSourceUpdateMode.OnPropertyChanged))
        'NumericUpDown1.DataBindings.Add("Value", DataSource.TemperatureThreshold, "Maximum", False, DataSourceUpdateMode.OnPropertyChanged)
        'SwitchButton1.DataBindings.Add("Value", DataSource.TemperatureThreshold, "IsRelayConnectWhenBeyondTheMaximum", False, DataSourceUpdateMode.OnPropertyChanged)

        'NumericUpDown2.DataBindings.Add("Value", DataSource.HumidityThreshold, "Maximum", False, DataSourceUpdateMode.OnPropertyChanged)
        'SwitchButton2.DataBindings.Add("Value", DataSource.HumidityThreshold, "IsRelayConnectWhenBeyondTheMaximum", False, DataSourceUpdateMode.OnPropertyChanged)

        'NumericUpDown3.DataBindings.Add("Value", DataSource.CO2Threshold, "Maximum", False, DataSourceUpdateMode.OnPropertyChanged)
        'SwitchButton3.DataBindings.Add("Value", DataSource.CO2Threshold, "IsRelayConnectWhenBeyondTheMaximum", False, DataSourceUpdateMode.OnPropertyChanged)

        'TrackBar1.Value = DataSource.StartTime
        'NumericUpDown1.Value = DataSource.TemperatureThreshold.Maximum
        'SwitchButton1.Value = DataSource.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum

        'NumericUpDown2.Value = DataSource.HumidityThreshold.Maximum
        'SwitchButton2.Value = DataSource.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum

        'NumericUpDown3.Value = DataSource.CO2Threshold.Maximum
        'SwitchButton3.Value = DataSource.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum

    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Label1.Text = $"开始 : {(TrackBar1.Value \ 2):d2}:{If(TrackBar1.Value Mod 2, 30, 0):d2}"
        'StartTime = TrackBar1.Value

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
