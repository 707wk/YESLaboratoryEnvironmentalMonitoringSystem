Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "产品版本号"
        Me.Text = $"{My.Application.Info.Title} V{AppSettingHelper.ProductVersion}"
#End Region

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

End Class