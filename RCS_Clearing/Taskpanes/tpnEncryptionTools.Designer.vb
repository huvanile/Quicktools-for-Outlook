<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tpnEncryptionTools
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tpnEncryptionTools))
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.lblCipherText = New System.Windows.Forms.Label()
        Me.txtCipherText = New System.Windows.Forms.TextBox()
        Me.txtMultilineCipher = New System.Windows.Forms.TextBox()
        Me.lblMultilineCipher = New System.Windows.Forms.Label()
        Me.rbSingleLine = New System.Windows.Forms.RadioButton()
        Me.rbMultiline = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDecrypt
        '
        Me.btnDecrypt.BackColor = System.Drawing.SystemColors.Control
        Me.btnDecrypt.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDecrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecrypt.Location = New System.Drawing.Point(162, 347)
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
        Me.btnEncrypt.Location = New System.Drawing.Point(57, 347)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(88, 33)
        Me.btnEncrypt.TabIndex = 12
        Me.btnEncrypt.Text = "Encrypt"
        Me.btnEncrypt.UseVisualStyleBackColor = False
        '
        'lblCipherText
        '
        Me.lblCipherText.AutoSize = True
        Me.lblCipherText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCipherText.Location = New System.Drawing.Point(9, 108)
        Me.lblCipherText.Name = "lblCipherText"
        Me.lblCipherText.Size = New System.Drawing.Size(186, 16)
        Me.lblCipherText.TabIndex = 14
        Me.lblCipherText.Text = "Single line encryption key"
        '
        'txtCipherText
        '
        Me.txtCipherText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCipherText.Location = New System.Drawing.Point(12, 131)
        Me.txtCipherText.Name = "txtCipherText"
        Me.txtCipherText.Size = New System.Drawing.Size(269, 22)
        Me.txtCipherText.TabIndex = 15
        '
        'txtMultilineCipher
        '
        Me.txtMultilineCipher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMultilineCipher.Location = New System.Drawing.Point(12, 187)
        Me.txtMultilineCipher.Multiline = True
        Me.txtMultilineCipher.Name = "txtMultilineCipher"
        Me.txtMultilineCipher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMultilineCipher.Size = New System.Drawing.Size(269, 142)
        Me.txtMultilineCipher.TabIndex = 16
        '
        'lblMultilineCipher
        '
        Me.lblMultilineCipher.AutoSize = True
        Me.lblMultilineCipher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMultilineCipher.Location = New System.Drawing.Point(9, 164)
        Me.lblMultilineCipher.Name = "lblMultilineCipher"
        Me.lblMultilineCipher.Size = New System.Drawing.Size(175, 16)
        Me.lblMultilineCipher.TabIndex = 17
        Me.lblMultilineCipher.Text = "Multi-line encryption key"
        '
        'rbSingleLine
        '
        Me.rbSingleLine.AutoSize = True
        Me.rbSingleLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSingleLine.Location = New System.Drawing.Point(15, 25)
        Me.rbSingleLine.Name = "rbSingleLine"
        Me.rbSingleLine.Size = New System.Drawing.Size(150, 20)
        Me.rbSingleLine.TabIndex = 18
        Me.rbSingleLine.Text = "Single line password"
        Me.rbSingleLine.UseVisualStyleBackColor = True
        '
        'rbMultiline
        '
        Me.rbMultiline.AutoSize = True
        Me.rbMultiline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMultiline.Location = New System.Drawing.Point(15, 51)
        Me.rbMultiline.Name = "rbMultiline"
        Me.rbMultiline.Size = New System.Drawing.Size(140, 20)
        Me.rbMultiline.TabIndex = 19
        Me.rbMultiline.Text = "Multi-line password"
        Me.rbMultiline.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSingleLine)
        Me.GroupBox1.Controls.Add(Me.rbMultiline)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 85)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encryption Key Type"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 396)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 123)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'tpnEncryptionTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMultilineCipher)
        Me.Controls.Add(Me.txtMultilineCipher)
        Me.Controls.Add(Me.txtCipherText)
        Me.Controls.Add(Me.lblCipherText)
        Me.Controls.Add(Me.btnDecrypt)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Name = "tpnEncryptionTools"
        Me.Size = New System.Drawing.Size(299, 600)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDecrypt As Windows.Forms.Button
    Friend WithEvents btnEncrypt As Windows.Forms.Button
    Friend WithEvents lblCipherText As Windows.Forms.Label
    Friend WithEvents txtCipherText As Windows.Forms.TextBox
    Friend WithEvents txtMultilineCipher As Windows.Forms.TextBox
    Friend WithEvents lblMultilineCipher As Windows.Forms.Label
    Friend WithEvents rbSingleLine As Windows.Forms.RadioButton
    Friend WithEvents rbMultiline As Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
