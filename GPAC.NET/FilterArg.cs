namespace GPAC.NET;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct FilterArg
{
    IntPtr name;
    int reserved;
    IntPtr description;
    IntPtr type;
    IntPtr @default;
    IntPtr min_max_enum;
    uint flags;


}