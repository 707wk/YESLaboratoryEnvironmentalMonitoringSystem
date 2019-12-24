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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UserRadioButton6 = New YESLaboratoryEnvironmentalMonitoringSystem.UserRadioButton()
        Me.UserRadioButton5 = New YESLaboratoryEnvironmentalMonitoringSystem.UserRadioButton()
        Me.UserRadioButton1 = New YESLaboratoryEnvironmentalMonitoringSystem.UserRadioButton()
        Me.UserRadioButton2 = New YESLaboratoryEnvironmentalMonitoringSystem.UserRadioButton()
        Me.UserRadioButton3 = New YESLaboratoryEnvironmentalMonitoringSystem.UserRadioButton()
        Me.UserRadioButton4 = New YESLaboratoryEnvironmentalMonitoringSystem.UserRadioButton()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.close_20px
        Me.Button2.Location = New System.Drawing.Point(815, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(104, 64)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(323, 6)
        Me.Panel3.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "开始 : 00:00"
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(91, 26)
        Me.TrackBar1.Maximum = 48
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(349, 30)
        Me.TrackBar1.TabIndex = 17
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDown1, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label26, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDown5, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDown6, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label28, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label29, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 5, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(446, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(369, 83)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 17)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "温度值"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.right_16px
        Me.Label10.Location = New System.Drawing.Point(168, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 22)
        Me.Label10.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(78, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 17)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "大于"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NumericUpDown1.Location = New System.Drawing.Point(116, 3)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(44, 23)
        Me.NumericUpDown1.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.right_16px
        Me.Label21.Location = New System.Drawing.Point(168, 29)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(22, 22)
        Me.Label21.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label22.Image = Global.YESLaboratoryEnvironmentalMonitoringSystem.My.Resources.Resources.right_16px
        Me.Label22.Location = New System.Drawing.Point(168, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 22)
        Me.Label22.TabIndex = 16
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(198, 32)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 17)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "继电器2"
        '
        'Panel6
        '
        Me.Panel6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel6.Controls.Add(Me.UserRadioButton6)
        Me.Panel6.Controls.Add(Me.UserRadioButton5)
        Me.Panel6.Location = New System.Drawing.Point(255, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(108, 21)
        Me.Panel6.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(198, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 17)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "继电器1"
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(198, 60)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(51, 17)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "继电器3"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel1.Controls.Add(Me.UserRadioButton1)
        Me.Panel1.Controls.Add(Me.UserRadioButton2)
        Me.Panel1.Location = New System.Drawing.Point(255, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(108, 23)
        Me.Panel1.TabIndex = 16
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(28, 32)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 17)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "湿度值"
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 60)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 17)
        Me.Label26.TabIndex = 13
        Me.Label26.Text = "CO2浓度值"
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NumericUpDown5.Location = New System.Drawing.Point(116, 30)
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(44, 23)
        Me.NumericUpDown5.TabIndex = 8
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.NumericUpDown6.Location = New System.Drawing.Point(116, 57)
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(44, 23)
        Me.NumericUpDown6.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(78, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(32, 17)
        Me.Label28.TabIndex = 14
        Me.Label28.Text = "大于"
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(78, 60)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(32, 17)
        Me.Label29.TabIndex = 14
        Me.Label29.Text = "大于"
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel2.Controls.Add(Me.UserRadioButton3)
        Me.Panel2.Controls.Add(Me.UserRadioButton4)
        Me.Panel2.Location = New System.Drawing.Point(255, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(108, 21)
        Me.Panel2.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "时长 : 00:00"
        '
        'UserRadioButton6
        '
        Me.UserRadioButton6.AutoSize = True
        Me.UserRadioButton6.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.UserRadioButton6.Location = New System.Drawing.Point(56, 0)
        Me.UserRadioButton6.Name = "UserRadioButton6"
        Me.UserRadioButton6.Size = New System.Drawing.Size(50, 21)
        Me.UserRadioButton6.TabIndex = 0
        Me.UserRadioButton6.TabStop = True
        Me.UserRadioButton6.Text = "断开"
        Me.UserRadioButton6.UseVisualStyleBackColor = True
        '
        'UserRadioButton5
        '
        Me.UserRadioButton5.AutoSize = True
        Me.UserRadioButton5.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.UserRadioButton5.Location = New System.Drawing.Point(0, 0)
        Me.UserRadioButton5.Name = "UserRadioButton5"
        Me.UserRadioButton5.Size = New System.Drawing.Size(50, 21)
        Me.UserRadioButton5.TabIndex = 0
        Me.UserRadioButton5.TabStop = True
        Me.UserRadioButton5.Text = "连通"
        Me.UserRadioButton5.UseVisualStyleBackColor = True
        '
        'UserRadioButton1
        '
        Me.UserRadioButton1.AutoSize = True
        Me.UserRadioButton1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.UserRadioButton1.Location = New System.Drawing.Point(56, 0)
        Me.UserRadioButton1.Name = "UserRadioButton1"
        Me.UserRadioButton1.Size = New System.Drawing.Size(50, 21)
        Me.UserRadioButton1.TabIndex = 0
        Me.UserRadioButton1.TabStop = True
        Me.UserRadioButton1.Text = "断开"
        Me.UserRadioButton1.UseVisualStyleBackColor = True
        '
        'UserRadioButton2
        '
        Me.UserRadioButton2.AutoSize = True
        Me.UserRadioButton2.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.UserRadioButton2.Location = New System.Drawing.Point(0, 0)
        Me.UserRadioButton2.Name = "UserRadioButton2"
        Me.UserRadioButton2.Size = New System.Drawing.Size(50, 21)
        Me.UserRadioButton2.TabIndex = 0
        Me.UserRadioButton2.TabStop = True
        Me.UserRadioButton2.Text = "连通"
        Me.UserRadioButton2.UseVisualStyleBackColor = True
        '
        'UserRadioButton3
        '
        Me.UserRadioButton3.AutoSize = True
        Me.UserRadioButton3.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.UserRadioButton3.Location = New System.Drawing.Point(56, 0)
        Me.UserRadioButton3.Name = "UserRadioButton3"
        Me.UserRadioButton3.Size = New System.Drawing.Size(50, 21)
        Me.UserRadioButton3.TabIndex = 0
        Me.UserRadioButton3.TabStop = True
        Me.UserRadioButton3.Text = "断开"
        Me.UserRadioButton3.UseVisualStyleBackColor = True
        '
        'UserRadioButton4
        '
        Me.UserRadioButton4.AutoSize = True
        Me.UserRadioButton4.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.UserRadioButton4.Location = New System.Drawing.Point(0, 0)
        Me.UserRadioButton4.Name = "UserRadioButton4"
        Me.UserRadioButton4.Size = New System.Drawing.Size(50, 21)
        Me.UserRadioButton4.TabIndex = 0
        Me.UserRadioButton4.TabStop = True
        Me.UserRadioButton4.Text = "连通"
        Me.UserRadioButton4.UseVisualStyleBackColor = True
        '
        'TimeBucketControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "TimeBucketControl"
        Me.Size = New System.Drawing.Size(846, 89)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents UserRadioButton6 As UserRadioButton
    Friend WithEvents UserRadioButton5 As UserRadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UserRadioButton1 As UserRadioButton
    Friend WithEvents UserRadioButton2 As UserRadioButton
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents NumericUpDown6 As NumericUpDown
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents UserRadioButton3 As UserRadioButton
    Friend WithEvents UserRadioButton4 As UserRadioButton
    Friend WithEvents Label2 As Label
End Class
