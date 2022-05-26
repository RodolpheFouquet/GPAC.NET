namespace GPAC.NET;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Fraction64 {
    
    public long Num { get; set; }
    public ulong Den { get; set; }

    public Fraction64(long num, ulong den)
    {
        Num = num;
        Den = den;
    }

    override public string ToString() {
        return String.Format("{0}/{1}", Num, Den);
    }
}