Imports System.Resources
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("Quicktools for Outlook")>
<Assembly: AssemblyDescription("Tools for quickness in Outlook")>
<Assembly: AssemblyCompany("Grant Thornton LLP")>
<Assembly: AssemblyProduct("Quicktools for Outlook")>
<Assembly: AssemblyCopyright("GNU GPL")>
<Assembly: AssemblyTrademark("")>

' Setting ComVisible to false makes the types in this assembly not visible 
' to COM components.  If you need to access a type in this assembly from 
' COM, set the ComVisible attribute to true on that type.
<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("b32b36e0-883c-4480-b316-8543840d3391")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")>
<Assembly: AssemblyFileVersion("1.0.0.0")>
<Assembly: NeutralResourcesLanguage("en")>
Friend Module DesignTimeConstants
    Public Const RibbonTypeSerializer As String = "Microsoft.VisualStudio.Tools.Office.Ribbon.Serialization.RibbonTypeCodeDomSerializer, Microsoft.VisualStudio.Tools.Office.Designer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Public Const RibbonBaseTypeSerializer As String = "System.ComponentModel.Design.Serialization.TypeCodeDomSerializer, System.Design"
    Public Const RibbonDesigner As String = "Microsoft.VisualStudio.Tools.Office.Ribbon.Design.RibbonDesigner, Microsoft.VisualStudio.Tools.Office.Designer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
End Module
