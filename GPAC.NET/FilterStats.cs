namespace GPAC.NET;
using System.Runtime.InteropServices;

using FilterSession = IntPtr;
using Filter = IntPtr;
using FilterPid = IntPtr;
using Packet = IntPtr;
using PropertyEntry = IntPtr;
using GpacList = IntPtr;

[StructLayout(LayoutKind.Sequential)]
public struct FilterStats {
	Filter filter;
	Filter filter_alias;
	ulong nb_tasks_done;
	ulong nb_pck_processed;
	ulong nb_bytes_processed;
	ulong nb_pck_sent;
	ulong nb_hw_pck_sent;
	uint nb_errors;
	ulong nb_bytes_sent;
	ulong time_process;
	int percent;
	IntPtr status;
	Bool report_updated;
	IntPtr name;
	IntPtr reg_name;
	IntPtr filter_id;
	Bool done;
	uint nb_pid_in;
	ulong nb_in_pck;
	uint nb_pid_out;
	ulong nb_out_pck;
	Bool min_eos;
	int type;
	int stream_type;
	int codecid;
	Fraction64 last_ts_sent;
	Fraction64 last_ts_drop;
}