Partial Class RibbonNewMessage
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonNewMessage))
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.grpSteg = Me.Factory.CreateRibbonGroup
        Me.btnStegEmail = Me.Factory.CreateRibbonButton
        Me.Tab1.SuspendLayout()
        Me.grpSteg.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.Tab1.ControlId.OfficeId = "TabNewMailMessage"
        Me.Tab1.Groups.Add(Me.grpSteg)
        Me.Tab1.Label = "TabNewMailMessage"
        Me.Tab1.Name = "Tab1"
        '
        'grpSteg
        '
        Me.grpSteg.Items.Add(Me.btnStegEmail)
        Me.grpSteg.Label = "Steganograpy"
        Me.grpSteg.Name = "grpSteg"
        '
        'btnStegEmail
        '
        Me.btnStegEmail.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnStegEmail.Image = CType(resources.GetObject("btnStegEmail.Image"), System.Drawing.Image)
        Me.btnStegEmail.Label = "Convert Email to Image"
        Me.btnStegEmail.Name = "btnStegEmail"
        Me.btnStegEmail.ShowImage = True
        '
        'RibbonNewMessage
        '
        Me.Name = "RibbonNewMessage"
        Me.RibbonType = "Microsoft.Outlook.Mail.Compose"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.grpSteg.ResumeLayout(False)
        Me.grpSteg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents grpSteg As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnStegEmail As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property RibbonNewMessage() As RibbonNewMessage
        Get
            Return Me.GetRibbon(Of RibbonNewMessage)()
        End Get
    End Property
End Class
