using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyCompany("Ryan Wentzel")]
[assembly: AssemblyProduct("Snippet Compiler")]
[assembly: AssemblyCopyright("Copyright © Ryan Wentzel 2012")]

#if DEBUG
[assembly: AssemblyConfiguration("Flavor=Debug")]
#else
[assembly: AssemblyConfiguration("Flavor=Retail")]
#endif
