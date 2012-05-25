using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Negar Scsi Manager")]
[assembly: AssemblyDescription("A managed .NET library for interacting with SCSI and ATA devices.")]
#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("RPN")]
[assembly: AssemblyProduct("Negar Scsi Manager")]
[assembly: AssemblyCopyright("Copyright © RPN 2012")]
[assembly: AssemblyTrademark("RPN")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("ff9668db-945b-4ba9-925a-bb0a8c4d62e7")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]


//Build event for installing in GAC:
//  "%ProgramFiles%\Microsoft SDKs\Windows\v6.0A\bin\gacutil.exe" /i "$(TargetPath)"