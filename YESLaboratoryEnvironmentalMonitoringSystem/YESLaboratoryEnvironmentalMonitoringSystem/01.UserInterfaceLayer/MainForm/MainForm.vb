Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "产品版本号"
        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.ProductVersion}"
#End Region

        UserRadioButton5.Checked = True
        UserRadioButton4.Checked = True
        UserRadioButton2.Checked = True

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For i001 = 0 To 4 - 1
            Dim addTimeBucketControl = New TimeBucketControl With {.UIMainForm = Me}
            FlowLayoutPanel1.Controls.Add(addTimeBucketControl)
            FlowLayoutPanel1.Controls.SetChildIndex(addTimeBucketControl, 0)
        Next
        CheckTime()
    End Sub

    Public Sub CheckTime()
        Dim tmpList() As TimeBucketControl = (From item As TimeBucketControl In FlowLayoutPanel1.Controls).ToArray

        For i001 = 0 To tmpList.Count - 1
            'FlowLayoutPanel1.Controls.SetChildIndex(tmpList(i001), i001)
            'Dim tmpTimeBucketControl = CType(tmpList(i001), TimeBucketControl)

            'If i001 = 0 Then
            '    tmpTimeBucketControl.IsOK(True)
            'Else
            '    tmpTimeBucketControl.IsOK(CType(tmpList(i001 - 1), TimeBucketControl).StartTime <= tmpTimeBucketControl.StartTime)
            'End If
            If i001 = 0 Then
                Continue For
            End If

            If tmpList(i001 - 1).StartTime > tmpList(i001).StartTime Then
                tmpList(i001).StartTime = tmpList(i001 - 1).StartTime
            End If

            tmpList(i001 - 1).StopTime = tmpList(i001).StartTime
            tmpList(i001 - 1).UpdateTimeCount()

            If i001 = tmpList.Count - 1 Then
                tmpList(i001).StopTime = 48
                tmpList(i001).UpdateTimeCount()
            End If

        Next
    End Sub

    Private Sub SetChildIndex(child As Control, newIndex As Integer)
        FlowLayoutPanel1.Controls.SetChildIndex(child, newIndex)
    End Sub

End Class