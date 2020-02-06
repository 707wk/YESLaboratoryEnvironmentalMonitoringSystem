<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TimeBucketControl
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SwitchButton1 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.SwitchButton2 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.SwitchButton3 = New DevComponents.DotNetBar.Controls.SwitchButton()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.close_20px
        Me.Button2.Location = New System.Drawing.Point(796, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(16, 64)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(434, 6)
        Me.Panel3.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "开始 : 00:00"
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(3, 26)
        Me.TrackBar1.Maximum = 48
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(460, 30)
        Me.TrackBar1.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(496, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 17)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "温度值 大于"
        '
        'Label10
        '
        Me.Label10.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.right_16px
        Me.Label10.Location = New System.Drawing.Point(630, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 22)
        Me.Label10.TabIndex = 16
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown1.DecimalPlaces = 1
        Me.NumericUpDown1.Location = New System.Drawing.Point(574, 8)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(50, 19)
        Me.NumericUpDown1.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.right_16px
        Me.Label21.Location = New System.Drawing.Point(630, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(22, 22)
        Me.Label21.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.right_16px
        Me.Label22.Location = New System.Drawing.Point(630, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 22)
        Me.Label22.TabIndex = 16
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(660, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 17)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "继电器2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(660, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 17)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "继电器1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(660, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(51, 17)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "继电器3"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(496, 36)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 17)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "湿度值 大于"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(471, 64)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(97, 17)
        Me.Label26.TabIndex = 13
        Me.Label26.Text = "CO2浓度值 大于"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown2.DecimalPlaces = 1
        Me.NumericUpDown2.Location = New System.Drawing.Point(574, 35)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(50, 19)
        Me.NumericUpDown2.TabIndex = 8
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumericUpDown3.Location = New System.Drawing.Point(574, 63)
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(50, 19)
        Me.NumericUpDown3.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "时长 : 00:00"
        '
        'SwitchButton1
        '
        '
        '
        '
        Me.SwitchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton1.Location = New System.Drawing.Point(717, 6)
        Me.SwitchButton1.Name = "SwitchButton1"
        Me.SwitchButton1.OffText = "断开"
        Me.SwitchButton1.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SwitchButton1.OnText = "连通"
        Me.SwitchButton1.Size = New System.Drawing.Size(66, 22)
        Me.SwitchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton1.TabIndex = 18
        '
        'SwitchButton2
        '
        '
        '
        '
        Me.SwitchButton2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton2.Location = New System.Drawing.Point(717, 33)
        Me.SwitchButton2.Name = "SwitchButton2"
        Me.SwitchButton2.OffText = "断开"
        Me.SwitchButton2.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SwitchButton2.OnText = "连通"
        Me.SwitchButton2.Size = New System.Drawing.Size(66, 22)
        Me.SwitchButton2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton2.TabIndex = 18
        '
        'SwitchButton3
        '
        '
        '
        '
        Me.SwitchButton3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton3.Location = New System.Drawing.Point(717, 61)
        Me.SwitchButton3.Name = "SwitchButton3"
        Me.SwitchButton3.OffText = "断开"
        Me.SwitchButton3.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SwitchButton3.OnText = "连通"
        Me.SwitchButton3.Size = New System.Drawing.Size(66, 22)
        Me.SwitchButton3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton3.TabIndex = 18
        '
        'TimeBucketControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.SwitchButton3)
        Me.Controls.Add(Me.SwitchButton2)
        Me.Controls.Add(Me.SwitchButton1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.NumericUpDown3)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "TimeBucketControl"
        Me.Size = New System.Drawing.Size(827, 89)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents SwitchButton1 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton2 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton3 As DevComponents.DotNetBar.Controls.SwitchButton
End Class
