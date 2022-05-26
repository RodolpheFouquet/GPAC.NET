namespace GPAC.NET;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Fraction {
    
    public int Num { get; set; }
    public uint Den { get; set; }

    public Fraction(int num, uint den)
    {
        Num = num;
        Den = den;
    }

    override public string ToString() {
        return String.Format("{0}/{1}", Num, Den);
    }
}