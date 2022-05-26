namespace GPAC.NET;

public enum Bool: uint {
    False = 0,
    True = 1
}

public static class BoolExtensions
{


	public static Bool FromBool(bool b)
	{
		if(b) return Bool.True;
		else  return Bool.False;	
	}

	public static bool IsTrue(this Bool b)
	{
		return b == Bool.True;
	}
}