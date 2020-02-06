Imports System.ComponentModel

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "产品版本号"
        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.ProductVersion}"
#End Region

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        GetSensorDataTimer.Interval = 1000
        GetSensorDataTimer.Start()

        '串口号
        With ComboBoxItem1
            .Items.AddRange(IO.Ports.SerialPort.GetPortNames())

            If .Items.Contains($"{AppSettingHelper.Settings.SerialPort}") Then
                .Text = AppSettingHelper.Settings.SerialPort
            ElseIf .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

        ControlState(False)

        ShowTimeBucket()

    End Sub

    Private Sub ShowTimeBucket()
        NumericUpDown1.Value = AppSettingHelper.Settings.DefaultTimeBucket.TemperatureThreshold.Maximum / 10
        SwitchButton1.Value = AppSettingHelper.Settings.DefaultTimeBucket.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum

        NumericUpDown2.Value = AppSettingHelper.Settings.DefaultTimeBucket.HumidityThreshold.Maximum / 10
        SwitchButton2.Value = AppSettingHelper.Settings.DefaultTimeBucket.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum

        NumericUpDown3.Value = AppSettingHelper.Settings.DefaultTimeBucket.CO2Threshold.Maximum
        SwitchButton3.Value = AppSettingHelper.Settings.DefaultTimeBucket.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum

        FlowLayoutPanel1.Controls.Clear()
        For Each item In AppSettingHelper.Settings.OtherTimeBucketItems
            Dim addTimeBucketControl = New TimeBucketControl With {.UIMainForm = Me, .DataSource = item}
            FlowLayoutPanel1.Controls.Add(addTimeBucketControl)
        Next

        CheckTime()
    End Sub

    Private Sub GetTimeBucket()
        AppSettingHelper.Settings.DefaultTimeBucket.TemperatureThreshold.Maximum = NumericUpDown1.Value * 10
        AppSettingHelper.Settings.DefaultTimeBucket.TemperatureThreshold.IsRelayConnectWhenBeyondTheMaximum = SwitchButton1.Value

        AppSettingHelper.Settings.DefaultTimeBucket.HumidityThreshold.Maximum = NumericUpDown2.Value * 10
        AppSettingHelper.Settings.DefaultTimeBucket.HumidityThreshold.IsRelayConnectWhenBeyondTheMaximum = SwitchButton2.Value

        AppSettingHelper.Settings.DefaultTimeBucket.CO2Threshold.Maximum = NumericUpDown3.Value
        AppSettingHelper.Settings.DefaultTimeBucket.CO2Threshold.IsRelayConnectWhenBeyondTheMaximum = SwitchButton3.Value

        AppSettingHelper.Settings.OtherTimeBucketItems.Clear()
        For Each item As TimeBucketControl In FlowLayoutPanel1.Controls
            AppSettingHelper.Settings.OtherTimeBucketItems.Add(item.DataSource)
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
            HardwareHelper.Connect(ComboBoxItem1.Text, AppSetting.BPS)
            ControlState(True)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, ButtonItem2.Text)
        End Try

    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        HardwareHelper.DisConnect()
        ControlState(False)

    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click

        GetSensorDataTimer.Stop()

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = ButtonItem4.Text,
            .ProgressBarStyle = ProgressBarStyle.Marquee
        }
            tmpDialog.Start(Sub()
                                Threading.Thread.Sleep(1000)
                                HardwareHelper.GetTimeBucket()
                            End Sub)

            GetSensorDataTimer.Start()

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Information, tmpDialog.Text)
                Exit Sub
            End If

            ShowTimeBucket()

        End Using
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        GetTimeBucket()

        GetSensorDataTimer.Stop()

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = ButtonItem5.Text,
            .ProgressBarStyle = ProgressBarStyle.Marquee
        }
            tmpDialog.Start(Sub()
                                Threading.Thread.Sleep(1000)
                                HardwareHelper.SetTimeBucket()
                            End Sub)

            GetSensorDataTimer.Start()

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Information, tmpDialog.Text)
                Exit Sub
            End If

            MsgBox($"{tmpDialog.Text}成功", MsgBoxStyle.Information, tmpDialog.Text)

        End Using

    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        GetSensorDataTimer.Stop()

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = ButtonItem6.Text,
            .ProgressBarStyle = ProgressBarStyle.Marquee
        }
            tmpDialog.Start(Sub()
                                Threading.Thread.Sleep(1000)
                                HardwareHelper.SetMCUDatetime()
                            End Sub)

            GetSensorDataTimer.Start()

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Information, tmpDialog.Text)
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

    Private Sub GetSensorDataTimer_Tick(sender As Object, e As EventArgs) Handles GetSensorDataTimer.Tick
        Try
            Dim tmp = HardwareHelper.GetSensorData

            TemperatureValue.Text = Math.Round(tmp(0) / 10, 1)
            HumidityValue.Text = Math.Round(tmp(1) / 10, 1)
            CO2Value.Text = tmp(2)

        Catch ex As Exception
        End Try

    End Sub
End Class