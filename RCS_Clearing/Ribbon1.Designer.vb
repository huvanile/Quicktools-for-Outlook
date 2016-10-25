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
        Me.btnRCSCheck = Me.Factory.CreateRibbonButton
        Me.Group2 = Me.Factory.CreateRibbonGroup
        Me.btnFeedback = Me.Factory.CreateRibbonButton
        Me.btnShare = Me.Factory.CreateRibbonButton
        Me.tabQT.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.Group2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabQT
        '
        Me.tabQT.Groups.Add(Me.Group1)
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
        'btnRCSCheck
        '
        Me.btnRCSCheck.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnRCSCheck.Image = CType(resources.GetObject("btnRCSCheck.Image"), System.Drawing.Image)
        Me.btnRCSCheck.Label = "Clear Conflicts"
        Me.btnRCSCheck.Name = "btnRCSCheck"
        Me.btnRCSCheck.ShowImage = True
        Me.btnRCSCheck.SuperTip = "Attempt to automatically clear open relationship checks"
        '
        'Group2
        '
        Me.Group2.Items.Add(Me.btnFeedback)
        Me.Group2.Items.Add(Me.btnShare)
        Me.Group2.Label = "Add-in Tools"
        Me.Group2.Name = "Group2"
        '
        'btnFeedback
        '
        Me.btnFeedback.Image = CType(resources.GetObject("btnFeedback.Image"), System.Drawing.Image)
        Me.btnFeedback.Label = "Contact the Developers"
        Me.btnFeedback.Name = "btnFeedback"
        Me.btnFeedback.ShowImage = True
        '
        'btnShare
        '
        Me.btnShare.Image = CType(resources.GetObject("btnShare.Image"), System.Drawing.Image)
        Me.btnShare.Label = "Share this Add-in"
        Me.btnShare.Name = "btnShare"
        Me.btnShare.ShowImage = True
        Me.btnShare.SuperTip = "Prepare an email to share this ribbon with a co-worker"
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
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As Ribbon1
        Get
            Return Me.GetRibbon(Of Ribbon1)()
        End Get
    End Property
End Class
