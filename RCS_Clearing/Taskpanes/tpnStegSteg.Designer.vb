<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tpnStegSteg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tpnStegSteg))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.btnFromFile = New System.Windows.Forms.Button()
        Me.btnFromImgur = New System.Windows.Forms.Button()
        Me.btnDoSteg = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(14, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(369, 266)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(14, 284)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.txtFilename.Size = New System.Drawing.Size(369, 20)
        Me.txtFilename.TabIndex = 8
        Me.txtFilename.TabStop = False
        '
        'btnFromFile
        '
        Me.btnFromFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFromFile.Location = New System.Drawing.Point(14, 317)
        Me.btnFromFile.Name = "btnFromFile"
        Me.btnFromFile.Size = New System.Drawing.Size(180, 37)
        Me.btnFromFile.TabIndex = 9
        Me.btnFromFile.Text = "Load Image From File"
        Me.btnFromFile.UseVisualStyleBackColor = True
        '
        'btnFromImgur
        '
        Me.btnFromImgur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFromImgur.Location = New System.Drawing.Point(203, 317)
        Me.btnFromImgur.Name = "btnFromImgur"
        Me.btnFromImgur.Size = New System.Drawing.Size(180, 37)
        Me.btnFromImgur.TabIndex = 10
        Me.btnFromImgur.Text = "Load Random Imgur Image"
        Me.btnFromImgur.UseVisualStyleBackColor = True
        '
        'btnDoSteg
        '
        Me.btnDoSteg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoSteg.Location = New System.Drawing.Point(14, 360)
        Me.btnDoSteg.Name = "btnDoSteg"
        Me.btnDoSteg.Size = New System.Drawing.Size(369, 35)
        Me.btnDoSteg.TabIndex = 12
        Me.btnDoSteg.Text = "Hide Current Email in This Image"
        Me.btnDoSteg.UseVisualStyleBackColor = True
        '
        'tpnStegSteg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDoSteg)
        Me.Controls.Add(Me.btnFromImgur)
        Me.Controls.Add(Me.btnFromFile)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "tpnStegSteg"
        Me.Size = New System.Drawing.Size(400, 573)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents txtFilename As Windows.Forms.TextBox
    Friend WithEvents btnFromFile As Windows.Forms.Button
    Friend WithEvents btnFromImgur As Windows.Forms.Button
    Friend WithEvents btnDoSteg As Windows.Forms.Button
End Class
