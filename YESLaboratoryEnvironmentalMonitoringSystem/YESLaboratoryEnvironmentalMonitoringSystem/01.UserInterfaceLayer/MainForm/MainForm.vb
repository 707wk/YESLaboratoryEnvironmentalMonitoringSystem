Imports System.ComponentModel
Imports System.Timers

Public Class MainForm

    ''' <summary>
    ''' 检测定时器
    ''' </summary>
    Private UpdateTimer As System.Timers.Timer

    Private SensorData(3 - 1) As List(Of Double)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "产品版本号"
        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.GetInstance.ProductVersion}"
#End Region

        '设置定时器
        UpdateTimer = New Timers.Timer
        UpdateTimer.AutoReset = True
        UpdateTimer.Enabled = True
        UpdateTimer.Interval = 2000
        AddHandler UpdateTimer.Elapsed, AddressOf GetSensorData
        '开启定时器
        UpdateTimer.Start()

#Region "走势图"
        With MicroChart1
            .BackColor = Color.FromArgb(56, 56, 60)
            .LineChartStyle.LineColor = Color.FromArgb(216, 99, 68)
            .LineChartStyle.LastPointColor = .LineChartStyle.LineColor
            .LineChartStyle.ZeroLineColor = Color.White
            .LineChartStyle.DrawZeroLine = True
            .AnimationEnabled = False
            .DataMinValue = 0
        End With

        With MicroChart2
            .BackColor = Color.FromArgb(56, 56, 60)
            .LineChartStyle.LineColor = Color.FromArgb(10, 190, 82)
            .LineChartStyle.LastPointColor = .LineChartStyle.LineColor
            .LineChartStyle.ZeroLineColor = Color.White
            .LineChartStyle.DrawZeroLine = True
            .AnimationEnabled = False
            .DataMinValue = 0
        End With

        With MicroChart3
            .BackColor = Color.FromArgb(56, 56, 60)
            .LineChartStyle.LineColor = Color.FromArgb(18, 150, 219)
            .LineChartStyle.LastPointColor = .LineChartStyle.LineColor
            .LineChartStyle.ZeroLineColor = Color.White
            .LineChartStyle.DrawZeroLine = True
            .AnimationEnabled = False
            .DataMinValue = 0
        End With

        For i001 = 0 To 3 - 1
            SensorData(i001) = New List(Of Double)
            For j001 = 0 To 30 - 1
                SensorData(i001).Add(0)
            Next
        Next

        MicroChart1.DataPoints = SensorData(0)
        MicroChart2.DataPoints = SensorData(1)
        MicroChart3.DataPoints = SensorData(2)
#End Region

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        AppSettingHelper.GetInstance.Logger.Info("程序启动")

        '串口号
        With ComboBoxItem1
            .Items.AddRange(IO.Ports.SerialPort.GetPortNames())

            If .Items.Contains($"{AppSettingHelper.GetInstance.SerialPort}") Then
                .Text = AppSettingHelper.GetInstance.SerialPort
            ElseIf .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

        ControlState(False)

        ShowTimeBucket()

    End Sub

    Private Sub ShowTimeBucket()
        NumericUpDown1.Value = AppSettingHelper.GetInstance.DefaultTimeBucket.TemperatureThreshold.Maximum / 10
        SwitchButton1.Value = AppSettingHelper.GetInstance.DefaultTimeBucket.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum

        NumericUpDown2.Value = AppSettingHelper.GetInstance.DefaultTimeBucket.HumidityThreshold.Maximum / 10
        SwitchButton2.Value = AppSettingHelper.GetInstance.DefaultTimeBucket.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum

        NumericUpDown3.Value = AppSettingHelper.GetInstance.DefaultTimeBucket.CO2Threshold.Maximum
        SwitchButton3.Value = AppSettingHelper.GetInstance.DefaultTimeBucket.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum

        FlowLayoutPanel1.Controls.Clear()
        For Each item In AppSettingHelper.GetInstance.OtherTimeBucketItems
            Dim addTimeBucketControl = New TimeBucketControl With {.UIMainForm = Me, .DataSource = item}
            FlowLayoutPanel1.Controls.Add(addTimeBucketControl)
        Next

        CheckTime()
    End Sub

    Private Sub GetTimeBucket()
        AppSettingHelper.GetInstance.DefaultTimeBucket.TemperatureThreshold.Maximum = NumericUpDown1.Value * 10
        AppSettingHelper.GetInstance.DefaultTimeBucket.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum = SwitchButton1.Value

        AppSettingHelper.GetInstance.DefaultTimeBucket.HumidityThreshold.Maximum = NumericUpDown2.Value * 10
        AppSettingHelper.GetInstance.DefaultTimeBucket.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum = SwitchButton2.Value

        AppSettingHelper.GetInstance.DefaultTimeBucket.CO2Threshold.Maximum = NumericUpDown3.Value
        AppSettingHelper.GetInstance.DefaultTimeBucket.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum = SwitchButton3.Value

        AppSettingHelper.GetInstance.OtherTimeBucketItems.Clear()
        For Each item As TimeBucketControl In FlowLayoutPanel1.Controls
            AppSettingHelper.GetInstance.OtherTimeBucketItems.Add(item.DataSource)
        Next

    End Sub

    Public Sub CheckTime()
        Dim tmpList() As TimeBucketControl = (From item As TimeBucketControl In FlowLayoutPanel1.Controls).ToArray

        For i001 = 0 To tmpList.Count - 1

            If i001 = tmpList.Count - 1 Then
                tmpList(i001).StopTime = 48
                tmpList(i001).UpdateTimeCount()
            End If

            If i001 = 0 Then
                Continue For
            End If

            If tmpList(i001 - 1).StartTime > tmpList(i001).StartTime Then
                tmpList(i001).StartTime = tmpList(i001 - 1).StartTime
            End If

            tmpList(i001 - 1).StopTime = tmpList(i001).StartTime
            tmpList(i001 - 1).UpdateTimeCount()

        Next
    End Sub

    Public Sub RemoveChild(child As TimeBucketControl)
        FlowLayoutPanel1.Controls.Remove(child)
        CheckTime()
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If HardwareHelper.IsOpen Then
            e.Cancel = True
            Exit Sub
        End If

        GetTimeBucket()
        AppSettingHelper.SaveToLocaltion()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        '串口号
        With ComboBoxItem1
            .Items.Clear()
            .Items.AddRange(IO.Ports.SerialPort.GetPortNames())

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With
    End Sub

#Region "连接后控件状态"
    ''' <summary>
    ''' 连接后控件状态
    ''' </summary>
    Private Sub ControlState(isConnect As Boolean)
        ComboBoxItem1.Enabled = Not isConnect
        ItemContainer2.Enabled = Not isConnect
        ButtonItem2.Enabled = Not isConnect
        ButtonItem3.Enabled = isConnect
        RibbonBar2.Enabled = isConnect
    End Sub
#End Region

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        If String.IsNullOrWhiteSpace(ComboBoxItem1.Text) Then
            Exit Sub
        End If

        Try
            HardwareHelper.Connect(ComboBoxItem1.Text, AppSettingHelper.BPS)
            ControlState(True)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, ButtonItem2.Text)
        End Try

    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        HardwareHelper.DisConnect()
        ControlState(False)

    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click

        UpdateTimer.Stop()

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = ButtonItem4.Text,
            .ProgressBarStyle = ProgressBarStyle.Marquee
        }
            tmpDialog.Start(Sub()
                                Threading.Thread.Sleep(1000)
                                HardwareHelper.GetTimeBucket()
                            End Sub)

            UpdateTimer.Start()

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Critical, tmpDialog.Text)
                Exit Sub
            End If

            ShowTimeBucket()

            MsgBox($"{tmpDialog.Text}成功", MsgBoxStyle.Information, tmpDialog.Text)

        End Using
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        GetTimeBucket()

        UpdateTimer.Stop()

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = ButtonItem5.Text,
            .ProgressBarStyle = ProgressBarStyle.Marquee
        }
            tmpDialog.Start(Sub()
                                Threading.Thread.Sleep(1000)
                                HardwareHelper.SetTimeBucket()
                            End Sub)

            UpdateTimer.Start()

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Critical, tmpDialog.Text)
                Exit Sub
            End If

            MsgBox($"{tmpDialog.Text}成功", MsgBoxStyle.Information, tmpDialog.Text)

        End Using

    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click

        UpdateTimer.Stop()

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = ButtonItem6.Text,
            .ProgressBarStyle = ProgressBarStyle.Marquee
        }
            tmpDialog.Start(Sub()
                                Threading.Thread.Sleep(1000)
                                HardwareHelper.SetMCUDatetime()
                            End Sub)

            UpdateTimer.Start()

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Critical, tmpDialog.Text)
                Exit Sub
            End If

            MsgBox($"{tmpDialog.Text}成功", MsgBoxStyle.Information, tmpDialog.Text)

        End Using
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If FlowLayoutPanel1.Controls.Count = 4 Then
            MsgBox("最多添加4个其他时间段", MsgBoxStyle.Information, ToolStripButton1.Text)
            Exit Sub
        End If

        If FlowLayoutPanel1.Controls.Count > 0 Then
            Dim lastTimeBucketControl As TimeBucketControl = FlowLayoutPanel1.Controls(FlowLayoutPanel1.Controls.Count - 1)
            Dim addTimeBucketControl As New TimeBucketControl With {.UIMainForm = Me, .StartTime = lastTimeBucketControl.StartTime}
            FlowLayoutPanel1.Controls.Add(addTimeBucketControl)
        Else
            Dim addTimeBucketControl As New TimeBucketControl With {.UIMainForm = Me}
            FlowLayoutPanel1.Controls.Add(addTimeBucketControl)
        End If

        CheckTime()
    End Sub

#Region "获取实时数据"
    ''' <summary>
    ''' 获取数据
    ''' </summary>
    Private IsUpdateEnd As Boolean = True
    ''' <summary>
    ''' 获取数据
    ''' </summary>
    Public Sub GetSensorData(Optional sender As Object = Nothing,
                            Optional e As ElapsedEventArgs = Nothing)

        If Not HardwareHelper.IsOpen Then
            Exit Sub
        End If

        '上一次没完成则不处理
        If Not IsUpdateEnd Then
            Exit Sub
        End If
        IsUpdateEnd = False

        Try
            Dim tmp = HardwareHelper.GetSensorData()

            UpdateSensorData(tmp)

        Catch ex As Exception
            Debug.WriteLine(Now & ex.Message)
        End Try

        IsUpdateEnd = True

    End Sub

    Public Delegate Sub UpdateSensorDataCallback(value As Integer())
    ''' <summary>
    ''' 更新数据
    ''' </summary>
    Public Sub UpdateSensorData(value As Integer())
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateSensorDataCallback(AddressOf UpdateSensorData), value)
            Exit Sub
        End If

        ToolStripStatusLabel1.Text = $"更新时间: {Now}"

        TemperatureValue.Text = Math.Round(value(0) / 10, 1)
        HumidityValue.Text = Math.Round(value(1) / 10, 1)
        CO2Value.Text = value(2)

        SensorData(0).RemoveAt(0)
        SensorData(0).Add(Math.Round(value(0) / 10, 1))
        MicroChart1.DataPoints = Nothing
        MicroChart1.DataPoints = SensorData(0)

        SensorData(1).RemoveAt(0)
        SensorData(1).Add(Math.Round(value(1) / 10, 1))
        MicroChart2.DataPoints = Nothing
        MicroChart2.DataPoints = SensorData(1)

        SensorData(2).RemoveAt(0)
        SensorData(2).Add(value(2))
        MicroChart3.DataPoints = Nothing
        MicroChart3.DataPoints = SensorData(2)

    End Sub
#End Region

End Class