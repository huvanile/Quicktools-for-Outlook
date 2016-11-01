<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tpnStegUnsteg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tpnStegUnsteg))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboAttachments = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecoveredText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(14, 71)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(369, 266)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'cboAttachments
        '
        Me.cboAttachments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAttachments.FormattingEnabled = True
        Me.cboAttachments.Location = New System.Drawing.Point(14, 36)
        Me.cboAttachments.Name = "cboAttachments"
        Me.cboAttachments.Size = New System.Drawing.Size(369, 23)
        Me.cboAttachments.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Text Message Retrieved From Picture"
        '
        'txtRecoveredText
        '
        Me.txtRecoveredText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecoveredText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecoveredText.Location = New System.Drawing.Point(14, 364)
        Me.txtRecoveredText.Multiline = True
        Me.txtRecoveredText.Name = "txtRecoveredText"
        Me.txtRecoveredText.ReadOnly = True
        Me.txtRecoveredText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRecoveredText.Size = New System.Drawing.Size(369, 144)
        Me.txtRecoveredText.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Attached Image to Inspect"
        '
        'tpnStegUnsteg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRecoveredText)
        Me.Controls.Add(Me.cboAttachments)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "tpnStegUnsteg"
        Me.Size = New System.Drawing.Size(400, 575)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents cboAttachments As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtRecoveredText As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
