<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tpnEncryptionTools
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
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.lblCipherText = New System.Windows.Forms.Label()
        Me.txtCipherText = New System.Windows.Forms.TextBox()
        Me.txtMultilineCipher = New System.Windows.Forms.TextBox()
        Me.lblMultilineCipher = New System.Windows.Forms.Label()
        Me.rbSingleLine = New System.Windows.Forms.RadioButton()
        Me.rbMultiline = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDecrypt
        '
        Me.btnDecrypt.BackColor = System.Drawing.SystemColors.Control
        Me.btnDecrypt.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDecrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecrypt.Location = New System.Drawing.Point(156, 340)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(88, 33)
        Me.btnDecrypt.TabIndex = 13
        Me.btnDecrypt.Text = "Decrypt"
        Me.btnDecrypt.UseVisualStyleBackColor = False
        '
        'btnEncrypt
        '
        Me.btnEncrypt.BackColor = System.Drawing.SystemColors.Control
        Me.btnEncrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEncrypt.Location = New System.Drawing.Point(51, 340)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(88, 33)
        Me.btnEncrypt.TabIndex = 12
        Me.btnEncrypt.Text = "Encrypt"
        Me.btnEncrypt.UseVisualStyleBackColor = False
        '
        'lblQuestion
        '
        Me.lblQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.ForeColor = System.Drawing.Color.Black
        Me.lblQuestion.Location = New System.Drawing.Point(47, 12)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(196, 65)
        Me.lblQuestion.TabIndex = 11
        Me.lblQuestion.Text = "Email Encryption Tools"
        Me.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCipherText
        '
        Me.lblCipherText.AutoSize = True
        Me.lblCipherText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCipherText.Location = New System.Drawing.Point(9, 122)
        Me.lblCipherText.Name = "lblCipherText"
        Me.lblCipherText.Size = New System.Drawing.Size(76, 13)
        Me.lblCipherText.TabIndex = 14
        Me.lblCipherText.Text = "Cipher Text:"
        '
        'txtCipherText
        '
        Me.txtCipherText.Location = New System.Drawing.Point(12, 139)
        Me.txtCipherText.Name = "txtCipherText"
        Me.txtCipherText.Size = New System.Drawing.Size(269, 20)
        Me.txtCipherText.TabIndex = 15
        '
        'txtMultilineCipher
        '
        Me.txtMultilineCipher.Location = New System.Drawing.Point(12, 192)
        Me.txtMultilineCipher.Multiline = True
        Me.txtMultilineCipher.Name = "txtMultilineCipher"
        Me.txtMultilineCipher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMultilineCipher.Size = New System.Drawing.Size(269, 142)
        Me.txtMultilineCipher.TabIndex = 16
        '
        'lblMultilineCipher
        '
        Me.lblMultilineCipher.AutoSize = True
        Me.lblMultilineCipher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMultilineCipher.Location = New System.Drawing.Point(9, 176)
        Me.lblMultilineCipher.Name = "lblMultilineCipher"
        Me.lblMultilineCipher.Size = New System.Drawing.Size(127, 13)
        Me.lblMultilineCipher.TabIndex = 17
        Me.lblMultilineCipher.Text = "Multiline Cipher Text:"
        '
        'rbSingleLine
        '
        Me.rbSingleLine.AutoSize = True
        Me.rbSingleLine.Location = New System.Drawing.Point(14, 21)
        Me.rbSingleLine.Name = "rbSingleLine"
        Me.rbSingleLine.Size = New System.Drawing.Size(110, 17)
        Me.rbSingleLine.TabIndex = 18
        Me.rbSingleLine.Text = "Single Line Cipher"
        Me.rbSingleLine.UseVisualStyleBackColor = True
        '
        'rbMultiline
        '
        Me.rbMultiline.AutoSize = True
        Me.rbMultiline.Location = New System.Drawing.Point(135, 21)
        Me.rbMultiline.Name = "rbMultiline"
        Me.rbMultiline.Size = New System.Drawing.Size(96, 17)
        Me.rbMultiline.TabIndex = 19
        Me.rbMultiline.Text = "Multiline Cipher"
        Me.rbMultiline.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSingleLine)
        Me.GroupBox1.Controls.Add(Me.rbMultiline)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 50)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cipher Type"
        '
        'tpnEncryptionTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMultilineCipher)
        Me.Controls.Add(Me.txtMultilineCipher)
        Me.Controls.Add(Me.txtCipherText)
        Me.Controls.Add(Me.lblCipherText)
        Me.Controls.Add(Me.btnDecrypt)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.lblQuestion)
        Me.Name = "tpnEncryptionTools"
        Me.Size = New System.Drawing.Size(300, 600)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDecrypt As Windows.Forms.Button
    Friend WithEvents btnEncrypt As Windows.Forms.Button
    Friend WithEvents lblQuestion As Windows.Forms.Label
    Friend WithEvents lblCipherText As Windows.Forms.Label
    Friend WithEvents txtCipherText As Windows.Forms.TextBox
    Friend WithEvents txtMultilineCipher As Windows.Forms.TextBox
    Friend WithEvents lblMultilineCipher As Windows.Forms.Label
    Friend WithEvents rbSingleLine As Windows.Forms.RadioButton
    Friend WithEvents rbMultiline As Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
End Class
