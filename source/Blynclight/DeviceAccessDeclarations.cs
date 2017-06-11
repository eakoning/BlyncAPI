using System;

namespace Blynclight
{
	internal class DeviceAccessDeclarations
	{
	    internal struct SP_DEVICE_INTERFACE_DATA
		{
			public int cbSize;

			public Guid InterfaceClassGuid;

			public int Flags;

			public UIntPtr Reserved;
		}

		internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			public int cbSize;

			public byte[] DevicePath;
		}

		internal struct SP_DEVINFO_DATA
		{
			public int cbSize;

			public Guid ClassGuid;

			public int DevInst;

			public IntPtr Reserved;
		}
	}
}