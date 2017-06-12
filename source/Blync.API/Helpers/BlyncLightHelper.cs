//using System;
//using System.ComponentModel;
//using System.Drawing;

//using Blynclight;

//namespace API.Helpers
//{
//    public class BlyncLightHelper
//    {
//        private const byte devicetypeNodeviceInvaliddeviceType = 0x00;

//        private const byte devicetypeBlyncChipsetTenx10 = 0x01;

//        private const byte devicetypeBlyncChipsetTenx20 = 0x02;

//        private const byte devicetypeBlyncChipsetV30 = 0x03;

//        private const byte devicetypeBlyncChipsetV30S = 0x04;

//        private const byte devicetypeBlyncHeadsetChipsetV30Lumena110 = 0x05;

//        private const byte devicetypeBlyncWirelessChipsetV30S = 0x06;

//        private const byte devicetypeBlyncMiniChipsetV30S = 0x07;

//        private const byte devicetypeBlyncHeadsetChipsetV30Lumena120 = 0x08;

//        private Color _defaultFlashColor = Color.Red;

//        // Create object for the base class BlynclightController
//        private readonly BlynclightController _blynclightController = new BlynclightController();

//        private readonly string[] _musicListForBlyncMiniWireless =
//            {
//                "Music 1", "Music 2", "Music 3", "Music 4", "Music 5",
//                "Music 6", "Music 7", "Music 8", "Music 9", "Music 10",
//                "Music 11", "Music 12", "Music 13", "Music 14"
//            };

//        private readonly string[] _musicListForBlyncUsb30S =
//            {
//                "Music 1", "Music 2", "Music 3", "Music 4", "Music 5",
//                "Music 6", "Music 7", "Music 8", "Music 9", "Music 10"
//            };

//        private readonly byte _selectedFlashSpeed = 1;

//        private readonly byte _selectedMusic = 1;

//        private readonly byte _volumeLevel = 5;

//        private int _numberOfBlyncDevices = 0;

//        private int _selectedDeviceIndex = 0;

//        public BlyncLightHelper()
//        {
//            Byte selectedFlashSpeed = 0x04;
//            Byte lightControl = 0x00;

//            lightControl |= (Byte)((selectedFlashSpeed & 0x0F) << 3);

//            //DisableUIComponentsForBlyncUsb1020Devices();
//            //DisableUIComponentsForBlyncUsb30Devices();

//            SearchAndListBlyncDevices();
//        }

//        public bool SetColor(int deviceId, string color)
//        {
//            Color parsedColor = ColorHelper.GetColorFromString(color);

//            return SetColor(deviceId, parsedColor);
//        }

//        public bool SetColor(int deviceId, Color color)
//        {
//            if (color == Color.Black)
//            {
//                return _blynclightController.TurnLedOff(deviceId);
//            }

//            return TurnOnRGBLights(deviceId, color.R, color.G, color.B);
//        }

//        public bool SetRGB(int deviceId, RGB rgb)
//        {
//            return TurnOnRGBLights(deviceId, rgb.Red, rgb.Green, rgb.Blue);
//        }

//        public bool Flash(int deviceId, FlashArguments flashArguments)
//        {
//            if (flashArguments.Speed == 0)
//            {
//                return _blynclightController.StopLightFlash(deviceId);
//            }
//            else
//            {
//                var setColorResult = SetColor(deviceId, flashArguments.Color ?? _defaultFlashColor);
//                var res = _blynclightController.SelectLightFlashSpeed(deviceId, Convert.ToByte(flashArguments.Speed));
//                return _blynclightController.StartLightFlash(deviceId);
//            }
//        }

//        public bool TurnOnRGBLights(int deviceId, byte red, byte green, byte blue)
//        {
//            return _blynclightController.TurnRGBLedOn(deviceId, red, green, blue);
//        }

//        private void SearchAndListBlyncDevices()
//        {
//            // Look for the Blync devices connected to the System
//            // the _numberOfBlyncDevices will be equal to the number 
//            // of Blync devices connected to the System USB Ports
//            _numberOfBlyncDevices = _blynclightController.InitBlyncDevices();

//            if (_numberOfBlyncDevices > 0)
//            {
//                // Add the Blync devices detected to the combobox
//                for (int i = 0; i < _numberOfBlyncDevices; i++)
//                {
//                    //comboBoxDeviceList.Items.Insert(i, _blynclightController.aoDevInfo[i].szDeviceName);

//                    if (_blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncChipsetTenx10 ||
//                        _blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncChipsetTenx20)
//                    {
//                        //EnableUIComponentsForBlyncUsb1020Devices();
//                        //DisableUIComponentsForBlyncUsb30Devices();
//                    }
//                    else if (_blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncChipsetV30S ||
//                             _blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncChipsetV30 ||
//                             _blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncHeadsetChipsetV30Lumena110 ||
//                             _blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncHeadsetChipsetV30Lumena120 ||
//                             _blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncWirelessChipsetV30S ||
//                             _blynclightController.aoDevInfo[i].byDeviceType == devicetypeBlyncMiniChipsetV30S)
//                    {
//                        EnableUIComponentsForBlyncUsb30Devices();
//                        //DisableUIComponentsForBlyncUsb1020Devices();
//                    }
//                }

//                //comboBoxDeviceList.SelectedIndex = 0;
//                _selectedDeviceIndex = 0;
//            }
//            else
//            {
//                //MessageBox.Show("No Blync Devices Detected", "Information",
//                //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

//                // If device is not present disable all UI components
//                //DisableUIComponentsForBlyncUsb1020Devices();
//                //DisableUIComponentsForBlyncUsb30Devices();
//            }
//        }

//        private void EnableUIComponentsForBlyncUsb30Devices()
//        {
//            if (_blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetV30S ||
//                _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncWirelessChipsetV30S ||
//                _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncMiniChipsetV30S)
//            {
//            }
//            else if (_blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetV30 ||
//                     _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncHeadsetChipsetV30Lumena110 ||
//                     _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncHeadsetChipsetV30Lumena120)
//            {
//            }
//        }

//        private void comboBoxDeviceList_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (_selectedDeviceIndex >= 0)
//            {
//                if (_blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetTenx10 ||
//                    _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetTenx20)
//                {
//                    //EnableUIComponentsForBlyncUsb1020Devices();
//                    //DisableUIComponentsForBlyncUsb30Devices();
//                }
//                else if (_blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetV30S ||
//                         _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetV30 ||
//                         _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncHeadsetChipsetV30Lumena110 ||
//                         _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncHeadsetChipsetV30Lumena120 ||
//                         _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncMiniChipsetV30S ||
//                         _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncWirelessChipsetV30S)
//                {
//                    EnableUIComponentsForBlyncUsb30Devices();
//                    //DisableUIComponentsForBlyncUsb1020Devices();

//                    if (_blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncChipsetV30S)
//                    {
//                        //if (comboBoxMusicList.Items.Count > 0)
//                        //{
//                        //    comboBoxMusicList.Items.Clear();
//                        //}

//                        for (int j = 0; j < _musicListForBlyncUsb30S.Length; j++)
//                        {
//                            //comboBoxMusicList.Items.Insert(j, arrMusicListForBlyncUSB30S[j]);
//                        }

//                        //comboBoxMusicList.SelectedIndex = 0;
//                    }
//                    else if (_blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncMiniChipsetV30S ||
//                             _blynclightController.aoDevInfo[_selectedDeviceIndex].byDeviceType == devicetypeBlyncWirelessChipsetV30S)
//                    {
//                        //if (comboBoxMusicList.Items.Count > 0)
//                        //{
//                        //    comboBoxMusicList.Items.Clear();
//                        //}

//                        for (int j = 0; j < _musicListForBlyncMiniWireless.Length; j++)
//                        {
//                            //comboBoxMusicList.Items.Insert(j, arrMusicListForBlyncMiniWireless[j]);
//                        }

//                        //comboBoxMusicList.SelectedIndex = 0;
//                    }
//                }
//            }
//        }

//        private void buttonRed_Click(object sender, EventArgs e)
//        {
//            // Call TurnOnRedLight and pass the nSelectedDeviceIndex.
//            // nSelectedDeviceIndex value will be updated on device selection in the Combo box

//            bool bResult = false;
//            bResult = _blynclightController.TurnOnRedLight(_selectedDeviceIndex);
//        }

//        private void buttonBlue_Click(object sender, EventArgs e)
//        {
//            _blynclightController.TurnOnBlueLight(_selectedDeviceIndex);
//        }

//        private void buttonMagenta_Click(object sender, EventArgs e)
//        {
//            _blynclightController.TurnOnMagentaLight(_selectedDeviceIndex);
//        }

//        private void buttonCyan_Click(object sender, EventArgs e)
//        {
//            _blynclightController.TurnOnCyanLight(_selectedDeviceIndex);
//        }

//        private void buttonGreen_Click(object sender, EventArgs e)
//        {
//            _blynclightController.TurnOnGreenLight(_selectedDeviceIndex);
//        }

//        private void buttonYellow_Click(object sender, EventArgs e)
//        {
//            _blynclightController.TurnOnYellowLight(_selectedDeviceIndex);
//        }

//        private void buttonWhite_Click(object sender, EventArgs e)
//        {
//            _blynclightController.TurnOnWhiteLight(_selectedDeviceIndex);
//        }

//        private void buttonResetEffects_Click(object sender, EventArgs e)
//        {
//            _blynclightController.ResetLight(_selectedDeviceIndex);
//        }

//        private void buttonUpdateDevList_Click(object sender, EventArgs e)
//        {
//            SearchAndListBlyncDevices();
//        }

//        private void Form1_Closing(object sender, CancelEventArgs e)
//        {
//            if (_numberOfBlyncDevices > 0)
//            {
//                _blynclightController.CloseDevices(_numberOfBlyncDevices);
//            }
//        }

//        private void checkBoxPlayMusic_CheckedChanged(object sender, EventArgs e)
//        {
//            bool bPlayMusic = true; //checkBoxPlayMusic.Checked;
//            bool bResult = false;

//            if (bPlayMusic == true)
//            {
//                bResult = _blynclightController.StartMusicPlay(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("StartMusicPlay failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }
//            else
//            {
//                bResult = _blynclightController.StopMusicPlay(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("StopMusicPlay failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }

//            bResult = _blynclightController.SelectMusicToPlay(_selectedDeviceIndex, _selectedMusic);
//            if (bResult == false)
//            {
//                //MessageBox.Show("SelectMusicToPlay failed", "Information",
//                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//            }

//            bResult = _blynclightController.SetMusicVolume(_selectedDeviceIndex, _volumeLevel);
//            if (bResult == false)
//            {
//                //MessageBox.Show("SetMusicVolume failed", "Information",
//                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//            }
//        }

//        private void checkBoxDimLight_CheckedChanged(object sender, EventArgs e)
//        {
//            bool bDimLight = true; //checkBoxDimLight.Checked;
//            bool bResult = false;

//            if (bDimLight == true)
//            {
//                bResult = _blynclightController.SetLightDim(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("SetLightDim failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }
//            else
//            {
//                bResult = _blynclightController.ClearLightDim(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("ClearLightDim failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }
//        }

//        private void checkBoxFlashLight_CheckedChanged(object sender, EventArgs e)
//        {
//            bool bFlashLight = true; //checkBoxFlashLight.Checked;
//            bool bResult = false;

//            if (bFlashLight == true)
//            {
//                bResult = _blynclightController.StartLightFlash(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("StartLightFlash failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }
//            else
//            {
//                bResult = _blynclightController.StopLightFlash(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("StopLightFlash failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }

//            // Select light flash speed
//            bResult = _blynclightController.SelectLightFlashSpeed(_selectedDeviceIndex, _selectedFlashSpeed);
//            if (bResult == false)
//            {
//                //MessageBox.Show("SelectLightFlashSpeed failed", "Information",
//                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//            }
//        }

//        private void checkBoxRepeatMusic_CheckedChanged(object sender, EventArgs e)
//        {
//            bool bRepeatMusic = true; //checkBoxRepeatMusic.Checked;
//            bool bResult = false;

//            if (bRepeatMusic == true)
//            {
//                bResult = _blynclightController.SetMusicRepeat(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("SetMusicRepeat failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }
//            else
//            {
//                bResult = _blynclightController.ClearMusicRepeat(_selectedDeviceIndex);
//                if (bResult == false)
//                {
//                    //MessageBox.Show("ClearMusicRepeat failed", "Information",
//                    //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//                }
//            }
//        }

//        //            MessageBox.Show("SelectLightFlashSpeed failed", "Information",
//        //        {

//        //private void comboBoxMusicList_SelectedIndexChanged(object sender, EventArgs e)
//        //{
//        //    bySelectedMusic = (Byte)(comboBoxMusicList.SelectedIndex + 1);

//        //    if (_blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
//        //    {
//        //        bool bResult = _blynclightController.SelectMusicToPlay(nSelectedDeviceIndex, bySelectedMusic);
//        //        if (bResult == false)
//        //        {
//        //            MessageBox.Show("SelectMusicToPlay failed", "Information",
//        //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//        //        }
//        //    }

//        //    /*if (comboBoxMusicList.Enabled == false)
//        //    {
//        //        return;
//        //    }

//        //    bool bResult = oBlynclightController.SelectMusicToPlay(nSelectedDeviceIndex, bySelectedMusic);
//        //    if (bResult == false)
//        //    {
//        //        MessageBox.Show("SelectMusicToPlay failed", "Information",
//        //            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//        //    }*/
//        //}

//        //private void comboBoxFlashSpeedList_SelectedIndexChanged(object sender, EventArgs e)
//        //{
//        //    bySelectedFlashSpeed = (Byte)(comboBoxFlashSpeedList.SelectedIndex + 1);

//        //    if (_blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
//        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
//        //    {
//        //        // Select light flash speed
//        //        bool bResult = _blynclightController.SelectLightFlashSpeed(nSelectedDeviceIndex, bySelectedFlashSpeed);

//        //        if (bResult == false)
//        //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//        //        }
//        //    }
//        //}

//        //private void trackBar1_Scroll(object sender, EventArgs e)
//        //{
//        //    byVolumeLevel = (Byte)trackBar1.Value;
//        //    bool bResult = false;

//        //    bResult = _blynclightController.SetMusicVolume(nSelectedDeviceIndex, byVolumeLevel);
//        //    if (bResult == false)
//        //    {
//        //        MessageBox.Show("SetMusicVolume failed", "Information",
//        //            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
//        //    }

//        //}

//        //private void vScrollBarRed_Scroll(object sender, ScrollEventArgs e)
//        //{
//        //    textBoxRed.Text = vScrollBarRed.Value.ToString();
//        //}

//        //private void vScrollBarGreen_Scroll(object sender, ScrollEventArgs e)
//        //{
//        //    textBoxGreen.Text = vScrollBarGreen.Value.ToString();
//        //}

//        //private void vScrollBarBlue_Scroll(object sender, ScrollEventArgs e)
//        //{
//        //    textBoxBlue.Text = vScrollBarBlue.Value.ToString();
//        //}
//    }
//}