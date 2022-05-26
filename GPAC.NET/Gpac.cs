namespace GPAC.NET;
using System.Runtime.InteropServices;

using FilterSession = IntPtr;
using Filter = IntPtr;
using FilterPid = IntPtr;
using Packet = IntPtr;
using PropertyEntry = IntPtr;
using GpacList = IntPtr;

public static class Gpac
{
    // native impots
    [DllImport("libgpac.dll", CharSet = CharSet.Unicode)]
    private static extern Error gf_sys_init(MemoryTrackerType mem_track, IntPtr profile);

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern Error gf_sys_close();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr gf_gpac_copyright_cite();   
    
    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr gf_gpac_version();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr gf_gpac_copyright();


    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern Error gf_memory_size();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern Error gf_file_handles_count();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern Error gf_log_set_tools_levels([MarshalAs(UnmanagedType.LPStr)] string logs, bool reset);

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong gf_sys_clock_high_res();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong gf_sys_clock();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr gf_log_get_tools_levels();

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern Error gf_sys_set_args(int argc, IntPtr argv);

    [DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void gf_sleep(ulong milliseconds);


    private static bool isInit = false;

    public static string IntPtrToString(IntPtr ptr)
    {
        var str = Marshal.PtrToStringAnsi(ptr);
        if (str == null)
        {
            throw new Exception("Failed to get string from GPAC");
        }
        return str;

    }

    public static void Init(MemoryTrackerType memTracking)
    {
        if (isInit) return;

        Close();
        var ret = gf_sys_init(memTracking, IntPtr.Zero);
        if (!ret.Success())
        {
            throw new GpacException(ret);
        }
        isInit = true;
    }

    public static void Close()
    {
        gf_sys_close();
        isInit = false;
    }

    public static string CopyrightCite()
    {
        return IntPtrToString(gf_gpac_copyright_cite());
    }

    public static string Version() {
        return IntPtrToString(gf_gpac_version()); 
    }    
    
    public static string Copyright() {
        return IntPtrToString(gf_gpac_copyright()); 
    }

    public static void SetLogLevel(string level, bool reset)
    {
        gf_log_set_tools_levels(level, reset);
    }

    public static ulong HighResClock()
    {
        return gf_sys_clock_high_res();
    }

    public static ulong SysClock()
    {
        return gf_sys_clock();
    }

    // Leak here, need access to gf_free to free the IntPtr returned by GPAC
    public static string GetLogLevel()
    {
        return IntPtrToString(gf_log_get_tools_levels());
    }

    public static void SetArgs(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            gf_sys_set_args(0, IntPtr.Zero);
        }

        List<IntPtr> allocatedMemory = new List<IntPtr>();

        int sizeOfIntPtr = Marshal.SizeOf(typeof(IntPtr));
        IntPtr pointersToArguments = Marshal.AllocHGlobal(sizeOfIntPtr * args.Length);

        // Turn each string of args into a char*
        for (int i = 0; i < args.Length; ++i)
        {
            IntPtr pointerToArgument = Marshal.StringToHGlobalAnsi(args[i]);
            allocatedMemory.Add(pointerToArgument);
            Marshal.WriteIntPtr(pointersToArguments, i * sizeOfIntPtr, pointerToArgument);
        }
        // call to GPAC
        var ret = gf_sys_set_args(args.Length, pointersToArguments);

        // free everything
        Marshal.FreeHGlobal(pointersToArguments);

        foreach (IntPtr pointer in allocatedMemory)
        {
            Marshal.FreeHGlobal(pointer);
        }

        if(!ret.Success())
            throw new GpacException(ret);
    }

    public static void Sleep(ulong milliseconds) {
        gf_sleep(milliseconds);
    }

}
