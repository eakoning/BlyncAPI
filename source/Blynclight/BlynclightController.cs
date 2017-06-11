using System;

namespace Blynclight
{
    public partial class BlynclightController
    {
        internal const byte DEVICETYPE_NODEVICE_INVALIDDEVICE_TYPE = 0;

        internal const byte DEVICETYPE_BLYNC_CHIPSET_TENX_10 = 1;

        internal const byte DEVICETYPE_BLYNC_CHIPSET_TENX_20 = 2;

        internal const byte DEVICETYPE_BLYNC_CHIPSET_V30 = 3;

        internal const byte DEVICETYPE_BLYNC_CHIPSET_V30S = 4;

        internal const byte DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 = 5;

        internal const byte DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S = 6;

        internal const byte DEVICETYPE_BLYNC_MINI_CHIPSET_V30S = 7;

        internal const byte DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 = 8;

        internal int _numberOfDevices;

        public DeviceInfo[] aoDevInfo = DeviceInfo.NewInitArray(10);

        internal bool bResult;

        internal byte byBlueValue;

        internal byte byBlyncControlCode = 255;

        internal byte byBlyncIBuddyLightColorMask = 112;

        internal byte byGreenValue;

        internal byte byLightControl;

        internal byte byMaskBit6Bit7 = 192;

        internal byte byMaskLightDimControl = 2;

        internal byte byMaskLightFlashOnOff = 4;

        internal byte byMaskLightFlashSpeed = 56;

        internal byte byMaskLightOnOff = 1;

        internal byte byMaskMusicOnOff = 16;

        internal byte byMaskMusicRepeatOnOff = 32;

        internal byte byMaskMusicSelect = 15;

        internal byte byMaskMute = 128;

        internal byte byMaskVolumeControl = 15;

        internal byte byMusicControl_1;

        internal byte byMusicControl_2;

        internal byte byRedValue;

        internal DeviceAccess oUsbDeviceAccess = new DeviceAccess();

        public bool ClearLightDim(int nDeviceIndex)
        {
            bResult = false;
            if (nDeviceIndex >= 0 && nDeviceIndex <= _numberOfDevices - 1)
                if (aoDevInfo[nDeviceIndex].byDeviceType == 3 || aoDevInfo[nDeviceIndex].byDeviceType == 4 || aoDevInfo[nDeviceIndex].byDeviceType == 6 || aoDevInfo[nDeviceIndex].byDeviceType == 7)
                {
                    var blynclightController = this;
                    blynclightController.byLightControl = (byte)(blynclightController.byLightControl & (byte)~byMaskLightDimControl);
                    bResult = oUsbDeviceAccess.SendBlyncUsb30ChipSetControlCommand(aoDevInfo[nDeviceIndex].pHandle, byRedValue, byGreenValue, byBlueValue, byLightControl, byMusicControl_1, byMusicControl_2);
                }
                else if (aoDevInfo[nDeviceIndex].byDeviceType == 5 || aoDevInfo[nDeviceIndex].byDeviceType == 8)
                {
                    var blynclightController1 = this;
                    blynclightController1.byLightControl = (byte)(blynclightController1.byLightControl & (byte)~byMaskLightDimControl);
                    bResult = oUsbDeviceAccess.SendBlyncUsbHeadset30ChipSetControlCommand(aoDevInfo[nDeviceIndex].pHandle, byRedValue, byGreenValue, byBlueValue, byLightControl);
                }
            return bResult;
        }

        public void CloseDevices(int nNumberOfDevices)
        {
            for (var i = 0; i < nNumberOfDevices; i++)
            {
                if (-1 != (uint)aoDevInfo[i].pHandle.ToInt64() && aoDevInfo[i].pHandle != IntPtr.Zero && (aoDevInfo[i].byDeviceType == 1 || aoDevInfo[i].byDeviceType == 3 || aoDevInfo[i].byDeviceType == 4 || aoDevInfo[i].byDeviceType == 5 || aoDevInfo[i].byDeviceType == 8 || aoDevInfo[i].byDeviceType == 6 || aoDevInfo[i].byDeviceType == 7))
                {
                    NativeMethods.CloseHandle(aoDevInfo[i].pHandle);
                    aoDevInfo[i].pHandle = IntPtr.Zero;
                }
            }
        }

        public int InitBlyncDevices()
        {
            var num = 0;
            if (_numberOfDevices > 0)
            {
                CloseDevices(_numberOfDevices);
            }

            _numberOfDevices = 0;
            LookForBlyncDevices(ref num);

            return num;
        }

        private bool LookForBlyncDevices(ref int numberOfDevices)
        {
            bResult = oUsbDeviceAccess.GetDevices(ref aoDevInfo, ref _numberOfDevices);
            numberOfDevices = _numberOfDevices;
            return bResult;
        }

        public bool SelectLightFlashSpeed(int deviceIndex, byte bySelectedFlashSpeed)
        {
            if (bySelectedFlashSpeed == 3)
            {
                bySelectedFlashSpeed = 4;
            }

            byLightControl = (byte)(byLightControl & (byte)~byMaskLightFlashSpeed);
            byLightControl = (byte)(byLightControl | (byte)((bySelectedFlashSpeed & 15) << 3));

            return ControlRGBLed(deviceIndex, byLightControl);
        }

        public bool SetLightDim(int deviceIndex)
        {
            byLightControl = (byte)(byLightControl | byMaskLightDimControl);
            return ControlRGBLed(deviceIndex, byLightControl, byRedValue, byGreenValue, byBlueValue);
        }

        public bool StartLightFlash(int deviceIndex)
        {
            byLightControl = (byte)(byLightControl | byMaskLightFlashOnOff);
            return ControlRGBLed(deviceIndex, byLightControl);
        }

        public bool StopLightFlash(int deviceIndex)
        {
            byLightControl = (byte)(byLightControl & (byte)~byMaskLightFlashOnOff);
            return ControlRGBLed(deviceIndex, byLightControl);
        }

        public bool TurnLedOff(int deviceIndex)
        {
            byLightControl = (byte)(byLightControl | byMaskLightOnOff);
            return ControlRGBLed(deviceIndex, byLightControl);
        }

        public bool TurnRGBLedOn(int deviceIndex, byte redLevel, byte greenLevel, byte blueLevel)
        {
            byLightControl = (byte)(byLightControl & (byte)~byMaskLightOnOff);
            return ControlRGBLed(deviceIndex, byLightControl, redLevel, greenLevel, blueLevel);
        }

        private bool ControlRGBLed(int deviceIndex, byte controlValue, byte redLevel, byte greenLevel, byte blueLevel)
        {
            byRedValue = redLevel;
            byGreenValue = greenLevel;
            byBlueValue = blueLevel;

            return ControlRGBLed(deviceIndex, controlValue);
        }

        private bool ControlRGBLed(int deviceIndex, byte controlValue)
        {
            if (deviceIndex >= 0 && deviceIndex <= _numberOfDevices - 1)
            {
                return oUsbDeviceAccess.SendBlyncUsb30ChipSetControlCommand(aoDevInfo[deviceIndex].pHandle, byRedValue, byGreenValue, byBlueValue, controlValue, byMusicControl_1, byMusicControl_2);
            }

            return false;
        }
    }
}