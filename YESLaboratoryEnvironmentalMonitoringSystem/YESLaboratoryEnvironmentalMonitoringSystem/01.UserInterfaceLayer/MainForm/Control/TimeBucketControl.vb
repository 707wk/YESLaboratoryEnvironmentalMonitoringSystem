Public Class TimeBucketControl

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

        UserRadioButton5.Checked = True
        UserRadioButton4.Checked = True
        UserRadioButton2.Checked = True
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Label1.Text = $"开始 : {(TrackBar1.Value \ 2):d2}:{If(TrackBar1.Value Mod 2, 30, 0):d2}"
        'StartTime = TrackBar1.Value


    End Sub

    Public Sub UpdateTimeCount()
        Dim changeX As Integer = 104 + 323 * StartTime / TrackBar1.Maximum
        Dim changeWidth As Integer = 323 * (StopTime - StartTime) / TrackBar1.Maximum

        Panel3.Location = New Point(changeX, Panel3.Location.Y)
        Panel3.Width = changeWidth

        Label2.Text = $"时长 : {((StopTime - StartTime) \ 2):d2}:{If((StopTime - StartTime) Mod 2, 30, 0):d2}"
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        UIMainForm.CheckTime()
    End Sub
End Class
