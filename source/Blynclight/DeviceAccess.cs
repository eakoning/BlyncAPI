using System;
using System.Runtime.InteropServices;

namespace Blynclight
{
    internal class DeviceAccess
    {
        internal byte[] abyBlyncIntOutputReportBuffer = new byte[65];

        internal byte[] abyBlyncOutputReportBuffer = new byte[9];

        internal byte[] abyBlyncUsbHeadsetOutputReportBuffer = new byte[16];

        internal IntPtr pspDeviceInterfaceData = IntPtr.Zero;

        internal IntPtr pspDeviceInterfaceDetailData = IntPtr.Zero;

        internal bool GetDevicePathName(ref Guid guid, IntPtr hDevInfo, uint uintDeviceID, ref string strDevicePathName)
        {
            var zero = IntPtr.Zero;
            var num = 0;
            var sPDEVICEINTERFACEDATum = new DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA();

            sPDEVICEINTERFACEDATum.cbSize = Marshal.SizeOf(sPDEVICEINTERFACEDATum);

            pspDeviceInterfaceData = Marshal.AllocHGlobal(Marshal.SizeOf(sPDEVICEINTERFACEDATum));
            Marshal.StructureToPtr(sPDEVICEINTERFACEDATum, pspDeviceInterfaceData, true);
            var flag = NativeMethods.SetupDiEnumDeviceInterfaces(hDevInfo, IntPtr.Zero, ref guid, uintDeviceID, pspDeviceInterfaceData);
            sPDEVICEINTERFACEDATum = (DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA)Marshal.PtrToStructure(pspDeviceInterfaceData, typeof(DeviceAccessDeclarations.SP_DEVICE_INTERFACE_DATA));
            if (flag)
            {
                flag = NativeMethods.SetupDiGetDeviceInterfaceDetail(hDevInfo, pspDeviceInterfaceData, IntPtr.Zero, num, ref num, IntPtr.Zero);
                pspDeviceInterfaceDetailData = Marshal.AllocHGlobal(num);
                Marshal.WriteInt32(pspDeviceInterfaceDetailData, IntPtr.Size == 4 ? 4 + Marshal.SystemDefaultCharSize : 8);
                flag = NativeMethods.SetupDiGetDeviceInterfaceDetail(hDevInfo, pspDeviceInterfaceData, pspDeviceInterfaceDetailData, num, ref num, IntPtr.Zero);
                var intPtr = new IntPtr(pspDeviceInterfaceDetailData.ToInt64() + 4);
                strDevicePathName = Marshal.PtrToStringAuto(intPtr);
            }
            if (pspDeviceInterfaceData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pspDeviceInterfaceData);
                pspDeviceInterfaceData = IntPtr.Zero;
            }
            if (pspDeviceInterfaceDetailData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pspDeviceInterfaceDetailData);
                pspDeviceInterfaceDetailData = IntPtr.Zero;
            }
            return flag;
        }

        internal bool GetDevices(ref BlynclightController.DeviceInfo[] aoDevInfo, ref int m_nTotalDevices)
        {
            uint num = 0;
            var zero = IntPtr.Zero;
            var intPtr = IntPtr.Zero;
            var devicePathName = true;
            uint i = 0;
            uint num1 = 0;
            uint num2 = 0;
            var guid = new Guid();
            var zero1 = IntPtr.Zero;
            var sPDEVINFODATum = new DeviceAccessDeclarations.SP_DEVINFO_DATA();
            NativeMethods.HidD_GetHidGuid(ref guid);
            var intPtr1 = IntPtr.Zero;
            num = 0;
            m_nTotalDevices = 0;
            zero = NativeMethods.SetupDiGetClassDevs(ref guid, IntPtr.Zero, IntPtr.Zero, 18);
            if (-1 != (uint)zero.ToInt64())
            {
                sPDEVINFODATum.cbSize = Marshal.SizeOf(sPDEVINFODATum);
                zero1 = Marshal.AllocHGlobal(Marshal.SizeOf(sPDEVINFODATum));
                Marshal.StructureToPtr(sPDEVINFODATum, zero1, true);
                for (i = 0; NativeMethods.SetupDiEnumDeviceInfo(zero, i, zero1); i++)
                {
                    sPDEVINFODATum = (DeviceAccessDeclarations.SP_DEVINFO_DATA)Marshal.PtrToStructure(zero1, typeof(DeviceAccessDeclarations.SP_DEVINFO_DATA));
                    while (!NativeMethods.SetupDiGetDeviceRegistryProperty(zero, zero1, 0, ref num1, intPtr1, num2, ref num2))
                        if (122 != Marshal.GetLastWin32Error())
                        {
                            devicePathName = false;
                            break;
                        }
                        else
                        {
                            intPtr1 = Marshal.AllocHGlobal((int)num2);
                        }
                    var intPtr2 = new IntPtr(intPtr1.ToInt64());
                    Marshal.PtrToStringAuto(intPtr2);
                    var empty = string.Empty;
                    devicePathName = GetDevicePathName(ref guid, zero, i, ref empty);
                    if (empty.Contains("vid_1130&pid_1e00&mi_01"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 2;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCUSB20 DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_1130&pid_0001&mi_01") || empty.Contains("vid_1130&pid_0002&mi_01"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 1;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCUSB10 DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_0e53&pid_2517") || empty.Contains("vid_2c0d&pid_0002"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 4;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCUSB30S DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_0e53&pid_2516") || empty.Contains("vid_2c0d&pid_0001"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 3;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCUSB30 DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_2c0d&pid_0004&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 5;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCUSB_HEADSET_LUMENA110 DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_2c0d&pid_0005&mi_03&col02"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 8;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCUSB_HEADSET_LUMENA120 DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_2c0d&pid_0006"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 6;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCLIGHT_WIRELESS DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                    else if (empty.Contains("vid_0e53&pid_2519") || empty.Contains("vid_2c0d&pid_0003"))
                    {
                        aoDevInfo[m_nTotalDevices].byDeviceType = 7;
                        aoDevInfo[m_nTotalDevices].szDeviceName = "BLYNCLIGHT_MINI DEVICE";
                        aoDevInfo[m_nTotalDevices].szDevicePath = empty;
                        aoDevInfo[m_nTotalDevices].pHandle = NativeMethods.CreateFile(empty, uint.MinValue, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                        m_nTotalDevices = m_nTotalDevices + 1;
                    }
                }
            }
            else
            {
                num = 6;
                devicePathName = false;
            }
            if (zero1 != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(zero1);
                zero1 = IntPtr.Zero;
            }
            if (intPtr1 != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(intPtr1);
                intPtr1 = IntPtr.Zero;
            }
            return devicePathName;
        }

        internal bool SendBlyncTenx10ChipSetControlCommand(IntPtr pHandle, byte byBlyncControlCode)
        {
            var flag = false;
            abyBlyncOutputReportBuffer[0] = 0;
            abyBlyncOutputReportBuffer[1] = 85;
            abyBlyncOutputReportBuffer[2] = 83;
            abyBlyncOutputReportBuffer[3] = 66;
            abyBlyncOutputReportBuffer[4] = 67;
            abyBlyncOutputReportBuffer[5] = 0;
            abyBlyncOutputReportBuffer[6] = 64;
            abyBlyncOutputReportBuffer[7] = 2;
            abyBlyncOutputReportBuffer[8] = byBlyncControlCode;
            flag = NativeMethods.HidD_SetOutputReport(pHandle, abyBlyncOutputReportBuffer, abyBlyncOutputReportBuffer.Length);
            return flag;
        }
        
        internal bool SendBlyncUsb30ChipSetControlCommand(IntPtr pHandle, byte byRedValue, byte byGreenValue, byte byBlueValue, byte byLightControl, byte byMusicControl_1, byte byMusicControl_2)
        {
            var flag = false;
            abyBlyncOutputReportBuffer[0] = 0;
            abyBlyncOutputReportBuffer[1] = byRedValue;
            abyBlyncOutputReportBuffer[2] = byBlueValue;
            abyBlyncOutputReportBuffer[3] = byGreenValue;
            abyBlyncOutputReportBuffer[4] = byLightControl;
            abyBlyncOutputReportBuffer[5] = byMusicControl_1;
            abyBlyncOutputReportBuffer[6] = byMusicControl_2;
            abyBlyncOutputReportBuffer[7] = 255;
            abyBlyncOutputReportBuffer[8] = 255;
            flag = NativeMethods.HidD_SetOutputReport(pHandle, abyBlyncOutputReportBuffer, abyBlyncOutputReportBuffer.Length);
            return flag;
        }

        internal bool SendBlyncUsbHeadset30ChipSetControlCommand(IntPtr pHandle, byte byRedValue, byte byGreenValue, byte byBlueValue, byte byLightControl)
        {
            var flag = false;
            for (var i = 0; i < abyBlyncUsbHeadsetOutputReportBuffer.Length; i++) abyBlyncUsbHeadsetOutputReportBuffer[i] = 0;
            abyBlyncUsbHeadsetOutputReportBuffer[0] = 5;
            abyBlyncUsbHeadsetOutputReportBuffer[8] = byRedValue;
            abyBlyncUsbHeadsetOutputReportBuffer[9] = byBlueValue;
            abyBlyncUsbHeadsetOutputReportBuffer[10] = byGreenValue;
            abyBlyncUsbHeadsetOutputReportBuffer[11] = byLightControl;
            flag = NativeMethods.HidD_SetOutputReport(pHandle, abyBlyncUsbHeadsetOutputReportBuffer, abyBlyncUsbHeadsetOutputReportBuffer.Length);
            return flag;
        }
    }
}