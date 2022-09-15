using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Goo Pumps & Oils' Speed Pump")]
[assembly: AssemblyDescription("Allows you to automatically transfer or balance fuel.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(GPOSpeedPump.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(GPOSpeedPump.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(GPOSpeedPump.LegalMamboJambo.Copyright)]
[assembly: AssemblyTrademark(GPOSpeedPump.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7f36aafb-927b-4d2b-8f2f-05b6c8e836fb")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion(GPOSpeedPump.Version.Number)]
[assembly: AssemblyFileVersion(GPOSpeedPump.Version.Number)]
[assembly: KSPAssembly("GPOSpeedPump", GPOSpeedPump.Version.major, GPOSpeedPump.Version.minor)]

#if KSPE
[assembly: KSPAssemblyDependency("KSPe", 2, 4)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 4)]
#else
[assembly: KSPAssemblyDependency("KSPe.Light.GPOSP", 2, 4)]
#endif