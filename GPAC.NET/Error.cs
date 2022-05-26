namespace GPAC.NET;
using System.Runtime.InteropServices;

public enum Error: int {
	/*!Message from any scripting engine used in the presentation (ECMAScript, MPEG-J, ...) (Info).*/
	ScriptInfo                                          = 3,
	/*!Indicates a send packet is not dispatched due to pending connections.*/
	PendingPacket					= 2,
	/*!Indicates the end of a stream or of a file (Info).*/
	EOS								= 1,

	/*!Operation success (no error).*/
	OK								= 0,

	/*!One of the input parameter is not correct or cannot be used in the current operating mode of the framework.*/
	BadParam							= -1,
	/*! Memory allocation failure.*/
	OutOfMem							= -2,
	/*! Input/Output failure (disk access, system call failures)*/
	IoErr								= -3,
	/*! The desired feature or operation is not supported by the framework*/
	NotSupported						= -4,
	/*! Input data has been corrupted*/
	CorruptedData						= -5,
	/*! A modification was attempted on a scene node which could not be found*/
	SgUnknownNode						= -6,
	/*! The PROTO node interface does not match the nodes using it*/
	SgInvalidProto						= -7,
	/*! An error occured in the scripting engine*/
	ScriptError							= -8,
	/*! Buffer is too small to contain decoded data. Decoders shall use this error whenever they need to resize their output memory buffers*/
	BufferTooSmall						= -9,
	/*! The bitstream is not compliant to the specfication it refers to*/
	NonCompliantBitstream				= -10,
	/*! No filter could be found to handle the desired media type*/
	FilterNotFound						= -11,
	/*! The URL is not properly formatted or cannot be found*/
	UrlError							= -12,
	/*! An service error has occured at the local side*/
	ServiceError						= -13,
	/*! A service error has occured at the remote (server) side*/
	RemoteServiceError					= -14,
	/*! The desired stream could not be found in the service*/
	StreamNotFound						= -15,
    /*! The URL no longer exists*/
    URL_REMOVED                          = -16,

	/*! The IsoMedia file is not a valid one*/
	ISOM_INVALID_FILE					= -20,
	/*! The IsoMedia file is not complete. Either the file is being downloaded, or it has been truncated*/
	IsomIncompleteFile					= -21,
	/*! The media in this IsoMedia track is not valid (usually due to a broken stream description)*/
	IsomInvalidMedia					= -22,
	/*! The requested operation cannot happen in the current opening mode of the IsoMedia file*/
	IsomInvalidMode					= -23,
	/*! This IsoMedia track refers to media outside the file in an unknown way*/
	IsomUnknownDataRef				= -24,

	/*! An invalid MPEG-4 Object Descriptor was found*/
	OdfInvalidDescriptor				= -30,
	/*! An MPEG-4 Object Descriptor was found or added to a forbidden descriptor*/
	OdfForbiddenDescriptor				= -31,
	/*! An invalid MPEG-4 BIFS command was detected*/
	OdfInvalidCommand					= -32,
	/*! The scene has been encoded using an unknown BIFS version*/
	BifsUnknownVersion					= -33,

	/*! The remote IP address could not be solved*/
	IpAddressNotFound					= -40,
	/*! The connection to the remote peer has failed*/
	IpConnectionFailure				= -41,
	/*! The network operation has failed*/
	IpNetworkFailure					= -42,
	/*! The network connection has been closed*/
	IpConnectionClosed					= -43,
	/*! The network operation has failed because no data is available*/
	IpNetworkEmpty						= -44,
	/*! The network operation has been discarded because it would be a blocking one*/
	IpSockWouldBlock					= -45,
	/*! UDP connection did not receive any data at all. Signaled by client services to reconfigure network if possible*/
	IpUdpTimeout						= -46,

	/*! Authentication with the remote host has failed*/
	AuthenticationFailure				= -50,
	/*! Script not ready for playback */
	ScriptNotReady						= -51,
	/*! Bad configuration for the current context */
	InvalidConfiguration				= -52,
	/*! The element has not been found */
	NotFound							= -53,
	/*! Unexpected format of data */
	ProfileNotSupported				= -54,
	/*! filter PID config requires new instance of filter */
	RequiresNewInstance = -56,
	/*! filter PID config cannot be supported by this filter, no use trying to find an alternate input filter chain*/
	FilterNotSupported = -57
}

public static class ErrorExtensions
{
	[DllImport("libgpac.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern IntPtr gf_error_to_string(Error error);
	public static bool Success(this Error err) {
        return err >= 0;
    }

	public static string ToErrorString(this Error err)
    {
		return Gpac.IntPtrToString(gf_error_to_string(err));
	}
}