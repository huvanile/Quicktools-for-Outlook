Partial Class Ribbon1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ribbon1))
        Me.tabQT = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.grpInbox = Me.Factory.CreateRibbonGroup
        Me.Group2 = Me.Factory.CreateRibbonGroup
        Me.btnRCSCheck = Me.Factory.CreateRibbonButton
        Me.btnInboxToExcel = Me.Factory.CreateRibbonButton
        Me.btnOpenVoicemails = Me.Factory.CreateRibbonButton
        Me.btnOpenRandomEmail = Me.Factory.CreateRibbonButton
        Me.btnOpenCalInvites = Me.Factory.CreateRibbonButton
        Me.btnOpenCalReplies = Me.Factory.CreateRibbonButton
        Me.btnFeedback = Me.Factory.CreateRibbonButton
        Me.btnShare = Me.Factory.CreateRibbonButton
        Me.xboxVIP1 = Me.Factory.CreateRibbonEditBox
        Me.xboxVIP2 = Me.Factory.CreateRibbonEditBox
        Me.xboxVIP3 = Me.Factory.CreateRibbonEditBox
        Me.btnVIP3 = Me.Factory.CreateRibbonButton
        Me.btnVIP2 = Me.Factory.CreateRibbonButton
        Me.btnVIP1 = Me.Factory.CreateRibbonButton
        Me.tabQT.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.grpInbox.SuspendLayout()
        Me.Group2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabQT
        '
        Me.tabQT.Groups.Add(Me.Group1)
        Me.tabQT.Groups.Add(Me.grpInbox)
        Me.tabQT.Groups.Add(Me.Group2)
        Me.tabQT.Label = "QUICKTOOLS"
        Me.tabQT.Name = "tabQT"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.btnRCSCheck)
        Me.Group1.Label = "GT Tools"
        Me.Group1.Name = "Group1"
        '
        'grpInbox
        '
        Me.grpInbox.Items.Add(Me.btnInboxToExcel)
        Me.grpInbox.Items.Add(Me.btnOpenVoicemails)
        Me.grpInbox.Items.Add(Me.btnOpenRandomEmail)
        Me.grpInbox.Items.Add(Me.btnOpenCalInvites)
        Me.grpInbox.Items.Add(Me.btnOpenCalReplies)
        Me.grpInbox.Items.Add(Me.btnVIP3)
        Me.grpInbox.Items.Add(Me.btnVIP2)
        Me.grpInbox.Items.Add(Me.btnVIP1)
        Me.grpInbox.Items.Add(Me.xboxVIP3)
        Me.grpInbox.Items.Add(Me.xboxVIP2)
        Me.grpInbox.Items.Add(Me.xboxVIP1)
        Me.grpInbox.Label = "Inbox Tools"
        Me.grpInbox.Name = "grpInbox"
        '
        'Group2
        '
        Me.Group2.Items.Add(Me.btnFeedback)
        Me.Group2.Items.Add(Me.btnShare)
        Me.Group2.Label = "Add-in Tools"
        Me.Group2.Name = "Group2"
        '
        'btnRCSCheck
        '
        Me.btnRCSCheck.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnRCSCheck.Image = CType(resources.GetObject("btnRCSCheck.Image"), System.Drawing.Image)
        Me.btnRCSCheck.Label = "Clear Conflicts"
        Me.btnRCSCheck.Name = "btnRCSCheck"
        Me.btnRCSCheck.ShowImage = True
        Me.btnRCSCheck.SuperTip = "Attempt to automatically clear open relationship checks"
        '
        'btnInboxToExcel
        '
        Me.btnInboxToExcel.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnInboxToExcel.Image = CType(resources.GetObject("btnInboxToExcel.Image"), System.Drawing.Image)
        Me.btnInboxToExcel.Label = "List Inbox in Excel"
        Me.btnInboxToExcel.Name = "btnInboxToExcel"
        Me.btnInboxToExcel.ShowImage = True
        '
        'btnOpenVoicemails
        '
        Me.btnOpenVoicemails.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnOpenVoicemails.Image = CType(resources.GetObject("btnOpenVoicemails.Image"), System.Drawing.Image)
        Me.btnOpenVoicemails.Label = "Open Inbox Voicemails"
        Me.btnOpenVoicemails.Name = "btnOpenVoicemails"
        Me.btnOpenVoicemails.ShowImage = True
        '
        'btnOpenRandomEmail
        '
        Me.btnOpenRandomEmail.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnOpenRandomEmail.Image = CType(resources.GetObject("btnOpenRandomEmail.Image"), System.Drawing.Image)
        Me.btnOpenRandomEmail.Label = "Open Random Inbox Email"
        Me.btnOpenRandomEmail.Name = "btnOpenRandomEmail"
        Me.btnOpenRandomEmail.ShowImage = True
        '
        'btnOpenCalInvites
        '
        Me.btnOpenCalInvites.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnOpenCalInvites.Image = CType(resources.GetObject("btnOpenCalInvites.Image"), System.Drawing.Image)
        Me.btnOpenCalInvites.Label = "Open Inbox Calendar Invites"
        Me.btnOpenCalInvites.Name = "btnOpenCalInvites"
        Me.btnOpenCalInvites.ShowImage = True
        '
        'btnOpenCalReplies
        '
        Me.btnOpenCalReplies.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnOpenCalReplies.Image = CType(resources.GetObject("btnOpenCalReplies.Image"), System.Drawing.Image)
        Me.btnOpenCalReplies.Label = "Open Inbox Calendar Replies"
        Me.btnOpenCalReplies.Name = "btnOpenCalReplies"
        Me.btnOpenCalReplies.ShowImage = True
        '
        'btnFeedback
        '
        Me.btnFeedback.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnFeedback.Image = CType(resources.GetObject("btnFeedback.Image"), System.Drawing.Image)
        Me.btnFeedback.Label = "Email the Developer"
        Me.btnFeedback.Name = "btnFeedback"
        Me.btnFeedback.ShowImage = True
        '
        'btnShare
        '
        Me.btnShare.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnShare.Image = CType(resources.GetObject("btnShare.Image"), System.Drawing.Image)
        Me.btnShare.Label = "Share this Add-in"
        Me.btnShare.Name = "btnShare"
        Me.btnShare.ShowImage = True
        Me.btnShare.SuperTip = "Prepare an email to share this ribbon with a co-worker"
        '
        'xboxVIP1
        '
        Me.xboxVIP1.Label = " "
        Me.xboxVIP1.Name = "xboxVIP1"
        Me.xboxVIP1.ShowLabel = False
        Me.xboxVIP1.SizeString = "xxxxxxxxxxxxxxxxxxx"
        '
        'xboxVIP2
        '
        Me.xboxVIP2.Label = " "
        Me.xboxVIP2.Name = "xboxVIP2"
        Me.xboxVIP2.ShowLabel = False
        Me.xboxVIP2.SizeString = "xxxxxxxxxxxxxxxxxxx"
        '
        'xboxVIP3
        '
        Me.xboxVIP3.Label = " "
        Me.xboxVIP3.Name = "xboxVIP3"
        Me.xboxVIP3.ShowLabel = False
        Me.xboxVIP3.SizeString = "xxxxxxxxxxxxxxxxxxx"
        '
        'btnVIP3
        '
        Me.btnVIP3.Image = CType(resources.GetObject("btnVIP3.Image"), System.Drawing.Image)
        Me.btnVIP3.Label = "Open Inbox Emails from:"
        Me.btnVIP3.Name = "btnVIP3"
        Me.btnVIP3.ShowImage = True
        '
        'btnVIP2
        '
        Me.btnVIP2.Image = CType(resources.GetObject("btnVIP2.Image"), System.Drawing.Image)
        Me.btnVIP2.Label = "Open Inbox Emails from:"
        Me.btnVIP2.Name = "btnVIP2"
        Me.btnVIP2.ShowImage = True
        '
        'btnVIP1
        '
        Me.btnVIP1.Image = CType(resources.GetObject("btnVIP1.Image"), System.Drawing.Image)
        Me.btnVIP1.Label = "Open Inbox Emails from:"
        Me.btnVIP1.Name = "btnVIP1"
        Me.btnVIP1.ShowImage = True
        '
        'Ribbon1
        '
        Me.Name = "Ribbon1"
        Me.RibbonType = "Microsoft.Outlook.Explorer"
        Me.Tabs.Add(Me.tabQT)
        Me.tabQT.ResumeLayout(False)
        Me.tabQT.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.grpInbox.ResumeLayout(False)
        Me.grpInbox.PerformLayout()
        Me.Group2.ResumeLayout(False)
        Me.Group2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnRCSCheck As Microsoft.Office.Tools.Ribbon.RibbonButton
    Public WithEvents tabQT As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group2 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnShare As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnFeedback As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpInbox As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnInboxToExcel As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnOpenVoicemails As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnOpenRandomEmail As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnOpenCalInvites As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnOpenCalReplies As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents xboxVIP1 As Microsoft.Office.Tools.Ribbon.RibbonEditBox
    Friend WithEvents xboxVIP2 As Microsoft.Office.Tools.Ribbon.RibbonEditBox
    Friend WithEvents xboxVIP3 As Microsoft.Office.Tools.Ribbon.RibbonEditBox
    Friend WithEvents btnVIP3 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnVIP2 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnVIP1 As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As Ribbon1
        Get
            Return Me.GetRibbon(Of Ribbon1)()
        End Get
    End Property
End Class
