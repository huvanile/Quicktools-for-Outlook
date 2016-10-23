<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tpnRCSStart
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tpnRCSStart))
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtEntities = New System.Windows.Forms.TextBox()
        Me.pboxDonate = New System.Windows.Forms.PictureBox()
        CType(Me.pboxDonate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblQuestion
        '
        Me.lblQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.ForeColor = System.Drawing.Color.Black
        Me.lblQuestion.Location = New System.Drawing.Point(14, 0)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(196, 65)
        Me.lblQuestion.TabIndex = 8
        Me.lblQuestion.Text = "Look for open RCS conflict cheks now?"
        Me.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(14, 68)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 33)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(119, 68)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 33)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(12, 116)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(198, 27)
        Me.lblStatus.TabIndex = 12
        Me.lblStatus.Text = "Status text"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEntities
        '
        Me.txtEntities.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntities.Location = New System.Drawing.Point(15, 162)
        Me.txtEntities.Multiline = True
        Me.txtEntities.Name = "txtEntities"
        Me.txtEntities.Size = New System.Drawing.Size(189, 221)
        Me.txtEntities.TabIndex = 14
        '
        'pboxDonate
        '
        Me.pboxDonate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pboxDonate.Image = CType(resources.GetObject("pboxDonate.Image"), System.Drawing.Image)
        Me.pboxDonate.Location = New System.Drawing.Point(18, 177)
        Me.pboxDonate.Name = "pboxDonate"
        Me.pboxDonate.Size = New System.Drawing.Size(186, 95)
        Me.pboxDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxDonate.TabIndex = 15
        Me.pboxDonate.TabStop = False
        Me.pboxDonate.Visible = False
        '
        'tpnRCSStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtEntities)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.pboxDonate)
        Me.Name = "tpnRCSStart"
        Me.Size = New System.Drawing.Size(219, 601)
        CType(Me.pboxDonate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblQuestion As Windows.Forms.Label
    Friend WithEvents btnOK As Windows.Forms.Button
    Friend WithEvents btnCancel As Windows.Forms.Button
    Public WithEvents lblStatus As Windows.Forms.Label
    Friend WithEvents txtEntities As Windows.Forms.TextBox
    Friend WithEvents pboxDonate As Windows.Forms.PictureBox
End Class
