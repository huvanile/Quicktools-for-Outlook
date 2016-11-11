Partial Class RibbonReceivedMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonReceivedMail))
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.btnRecoverSteg = Me.Factory.CreateRibbonButton
        Me.btnDecryptMessage = Me.Factory.CreateRibbonButton
        Me.Tab1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.Tab1.Groups.Add(Me.Group1)
        Me.Tab1.Label = "TabAddIns"
        Me.Tab1.Name = "Tab1"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.btnRecoverSteg)
        Me.Group1.Items.Add(Me.btnDecryptMessage)
        Me.Group1.Label = "QuickTools"
        Me.Group1.Name = "Group1"
        '
        'btnRecoverSteg
        '
        Me.btnRecoverSteg.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnRecoverSteg.Image = CType(resources.GetObject("btnRecoverSteg.Image"), System.Drawing.Image)
        Me.btnRecoverSteg.Label = "Read message hidden in attached image"
        Me.btnRecoverSteg.Name = "btnRecoverSteg"
        Me.btnRecoverSteg.ShowImage = True
        '
        'btnDecryptMessage
        '
        Me.btnDecryptMessage.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnDecryptMessage.Image = CType(resources.GetObject("btnDecryptMessage.Image"), System.Drawing.Image)
        Me.btnDecryptMessage.Label = "Decrypt Message"
        Me.btnDecryptMessage.Name = "btnDecryptMessage"
        Me.btnDecryptMessage.ShowImage = True
        '
        'RibbonReceivedMail
        '
        Me.Name = "RibbonReceivedMail"
        Me.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Read, Microsoft.Outlook.Post.R" &
    "ead, Microsoft.Outlook.Response.Read"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnRecoverSteg As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnDecryptMessage As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property RibbonReceivedMail() As RibbonReceivedMail
        Get
            Return Me.GetRibbon(Of RibbonReceivedMail)()
        End Get
    End Property
End Class
