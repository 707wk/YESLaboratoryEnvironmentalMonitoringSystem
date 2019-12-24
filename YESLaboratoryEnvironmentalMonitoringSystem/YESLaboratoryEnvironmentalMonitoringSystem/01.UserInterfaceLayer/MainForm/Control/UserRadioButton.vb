Public Class UserRadioButton
    Inherits RadioButton

    Public Sub New()
        Me.Font = New Font("微软雅黑", 9)
        'Me.AutoSize = False

        Me.DoubleBuffered = True
        'Me.FlatStyle = FlatStyle.Flat
        'Me.FlatAppearance.BorderSize = 0
        'Me.Appearance = Appearance.Button
    End Sub

    Private Sub AttributeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles Me.CheckedChanged
        If Me.Checked Then
            Me.BackColor = Color.FromArgb(221, 101, 114) '255, 102, 0)
            'Me.ForeColor = Color.White
        Else
            Me.BackColor = Color.FromArgb(56, 56, 60)
            'Me.ForeColor = SystemColors.ControlText
        End If
    End Sub

End Class
