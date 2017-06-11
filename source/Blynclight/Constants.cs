using System;

namespace Blynclight
{
	internal class Constants
	{
		internal const uint INVALID_HANDLE_VALUE = 4294967295;

		internal const uint ERROR_INVALID_HANDLE = 6;

		internal const uint ERROR_INSUFFICIENT_BUFFER = 122;

		internal const uint GENERIC_READ = 2147483648;

		internal const uint GENERIC_WRITE = 1073741824;

		internal const uint FILE_SHARE_READ = 1;

		internal const uint FILE_SHARE_WRITE = 2;

		internal const uint FILE_FLAG_OVERLAPPED = 1073741824;

		internal const uint OPEN_EXISTING = 3;

		internal const uint NO_ERROR = 0;

		internal const uint DIGCF_DEFAULT = 1;

		internal const uint DIGCF_PRESENT = 2;

		internal const uint DIGCF_ALLCLASSES = 4;

		internal const uint DIGCF_PROFILE = 8;

		internal const uint DIGCF_DEVICEINTERFACE = 16;

		internal const uint SPDRP_DEVICEDESC = 0;

		public Constants()
		{
		}
	}
}