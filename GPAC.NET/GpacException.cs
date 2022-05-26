namespace GPAC.NET;
using System.Runtime.InteropServices;


public class GpacException : Exception{

    public GpacException(Error err) : base(err.ToErrorString())
    {
    }

}