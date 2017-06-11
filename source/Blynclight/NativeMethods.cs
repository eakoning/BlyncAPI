using System;
using System.Runtime.InteropServices;

namespace Blynclight
{
	internal class NativeMethods
	{
	    [DllImport("kernel32.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool CloseHandle(IntPtr pHandle);

		[DllImport("kernel32.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("kernel32.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern uint GetLastError();

		[DllImport("hid.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern void HidD_GetHidGuid(ref Guid HidGuid);

		[DllImport("hid.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool HidD_SetFeature(IntPtr HidDeviceObject, byte[] lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, int ReportBufferLength);

		[DllImport("setupapi.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool SetupDiEnumDeviceInfo(IntPtr hDevInfo, uint uintDeviceID, IntPtr psDeviceInfoData);

		[DllImport("setupapi.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, IntPtr DeviceInfoData, ref Guid InterfaceClassGuid, uint MemberIndex, IntPtr psDeviceInterfaceData);

		[DllImport("setupapi.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, uint Flags);

		[DllImport("setupapi.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, IntPtr pspDeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

		[DllImport("setupapi.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool SetupDiGetDeviceRegistryProperty(IntPtr DeviceInfoSet, IntPtr psDeviceInfoData, uint Property, ref uint PropertyRegDataType, IntPtr pchBuffer, uint uintBufferSize, ref uint untBufferSize);

		[DllImport("kernel32.dll", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		internal static extern bool WriteFile(IntPtr pHandle, byte[] lpReportBuffer, uint unReportBufferSize, ref uint lpBytesReturned, IntPtr lpOverlapped);
	}
}