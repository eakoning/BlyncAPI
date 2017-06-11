using System;

namespace Blynclight
{
    public partial class BlynclightController
    {
        public class DeviceInfo
        {
            public byte byDeviceType;

            internal IntPtr pHandle;

            public string szDeviceName;

            internal string szDevicePath;

            public DeviceInfo()
            {
            }

            internal static BlynclightController.DeviceInfo[] NewInitArray(ulong num)
            {
                BlynclightController.DeviceInfo[] deviceInfo = new BlynclightController.DeviceInfo[num];
                for (ulong i = (ulong)0; i < num; i = i + (long)1)
                {
                    deviceInfo[i] = new BlynclightController.DeviceInfo();
                }
                return deviceInfo;
            }
        }
    }
}