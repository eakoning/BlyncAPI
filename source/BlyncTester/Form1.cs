using System;
using System.ComponentModel;
using System.Windows.Forms;
using Blynclight;

namespace BlyncTester
{
    public partial class Form1 : Form
    {
        // Create object for the base class BlynclightController
        private readonly BlynclightController _blynclightController = new BlynclightController();

        private int nNumberOfBlyncDevices = 0;
        private int nSelectedDeviceIndex = 0;

        internal const byte DEVICETYPE_NODEVICE_INVALIDDEVICE_TYPE = 0x00;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_TENX_10 = 0x01;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_TENX_20 = 0x02;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_V30 = 0x03;
        internal const byte DEVICETYPE_BLYNC_CHIPSET_V30S = 0x04;
        internal const byte DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 = 0x05;
        internal const byte DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S = 0x06;
        internal const byte DEVICETYPE_BLYNC_MINI_CHIPSET_V30S = 0x07;
        internal const byte DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 = 0x08;

        private byte bySelectedMusic = 1;
        private byte bySelectedFlashSpeed = 1;

        public Form1()
        {
            InitializeComponent();

            // Form_Closing event while exiting the application
            this.Closing += Form1_Closing;

            Byte bySelectedFlashSpeed = 0x04;
            Byte byLightControl = 0x00;
            
            //byLightControl |= (Byte)((bySelectedFlashSpeed & 0x0F) << 3);

            SearchAndListBlyncDevices();

            comboBoxFlashSpeedList.SelectedIndex = 0;
        }
        
        private void SearchAndListBlyncDevices()
        {
            // If there is already a list of devices, free the list of device and resources allocated
            //comboBoxDeviceList.Items.Clear();

            // Look for the Blync devices connected to the System
            // the nNumberOfBlyncDevices will be equal to the number 
            // of Blync devices connected to the System USB Ports
            nNumberOfBlyncDevices = _blynclightController.InitBlyncDevices();

            if (nNumberOfBlyncDevices > 0)
            {
                //// Add the Blync devices detected to the combobox
                //for (int i = 0; i < nNumberOfBlyncDevices; i++)
                //{
                //    //comboBoxDeviceList.Items.Insert(i, oBlynclightController.aoDevInfo[i].szDeviceName);

                //    //if (oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
                //    //    oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
                //    //{
                //    //    EnableUIComponentsForBlyncUsb1020Devices();
                //    //    DisableUIComponentsForBlyncUsb30Devices();
                //    //}
                //    //else if (oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                //    //    oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                //    //    oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                //    //    oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
                //    //    oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
                //    //    oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
                //    //{
                //    //    EnableUIComponentsForBlyncUsb30Devices();
                //    //    DisableUIComponentsForBlyncUsb1020Devices();
                //    //}
                //}

                //comboBoxDeviceList.SelectedIndex = 0;
                nSelectedDeviceIndex = 0;
            }
            else
            {
                MessageBox.Show("No Blync Devices Detected", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        

        //private void EnableUIComponentsForBlyncUsb30Devices()
        //{
        //    if (_blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
        //    {
        //        groupBoxLightControls.Enabled = true;
        //        groupBoxMusicControls.Enabled = true;
        //    }
        //    else if (_blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
        //        _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120)
        //    {
        //        groupBoxLightControls.Enabled = true;
        //        groupBoxMusicControls.Enabled = false;
        //    }
        //}

        //private void comboBoxDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    nSelectedDeviceIndex = comboBoxDeviceList.SelectedIndex;

        //    if (nSelectedDeviceIndex >= 0)
        //    {
        //        if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
        //        {
        //            EnableUIComponentsForBlyncUsb1020Devices();
        //            DisableUIComponentsForBlyncUsb30Devices();
        //        }
        //        else if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
        //        {
        //            EnableUIComponentsForBlyncUsb30Devices();
        //            DisableUIComponentsForBlyncUsb1020Devices();

        //            if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S)
        //            {
        //                if (comboBoxMusicList.Items.Count > 0)
        //                {
        //                    comboBoxMusicList.Items.Clear();                            
        //                }

        //                for (int j = 0; j < arrMusicListForBlyncUSB30S.Length; j++)
        //                {
        //                    comboBoxMusicList.Items.Insert(j, arrMusicListForBlyncUSB30S[j]);
        //                }

        //                comboBoxMusicList.SelectedIndex = 0;
        //            }
        //            else if (oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
        //            oBlynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
        //            {
        //                if (comboBoxMusicList.Items.Count > 0)
        //                {
        //                    comboBoxMusicList.Items.Clear();
        //                }

        //                for (int j = 0; j < arrMusicListForBlyncMiniWireless.Length; j++)
        //                {
        //                    comboBoxMusicList.Items.Insert(j, arrMusicListForBlyncMiniWireless[j]);
        //                }

        //                comboBoxMusicList.SelectedIndex = 0;
        //            }
        //        }
        //    }
        //}
        
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (nNumberOfBlyncDevices > 0)
            {
                for (int i = 0; i < nNumberOfBlyncDevices; i++)
                {
                    _blynclightController.TurnLedOff(i);
                }

                _blynclightController.CloseDevices(nNumberOfBlyncDevices);
            }
        }

        private void checkBoxDisplayLight_CheckedChanged(object sender, EventArgs e)
        {
            bool bDisplayLight = checkBoxDisplayLight.Checked;
            bool bResult = false;

            // Select turn on or off light based on check box value
            if (bDisplayLight == true)
            {
                // Send the RGB color values
                SetRgbValues();
            }
            else
            {
                bResult = _blynclightController.TurnLedOff(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("TurnOffLight failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }
        
        private void checkBoxDimLight_CheckedChanged(object sender, EventArgs e)
        {
            bool bDimLight = checkBoxDimLight.Checked;
            bool bResult = false;

            if (bDimLight == true)
            {
                bResult = _blynclightController.SetLightDim(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("SetLightDim failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = _blynclightController.ClearLightDim(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("ClearLightDim failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void checkBoxFlashLight_CheckedChanged(object sender, EventArgs e)
        {
            bool bFlashLight = checkBoxFlashLight.Checked;
            bool bResult = false;

            if (bFlashLight == true)
            {
                bResult = _blynclightController.StartLightFlash(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StartLightFlash failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bResult = _blynclightController.StopLightFlash(nSelectedDeviceIndex);
                if (bResult == false)
                {
                    MessageBox.Show("StopLightFlash failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            // Select light flash speed
            bResult = _blynclightController.SelectLightFlashSpeed(nSelectedDeviceIndex, bySelectedFlashSpeed);
            if (bResult == false)
            {
                MessageBox.Show("SelectLightFlashSpeed failed", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        
        private void buttonSetRgbValues_Click(object sender, EventArgs e)
        {
            SetRgbValues();
        }

        private void SetRgbValues()
        {
            Boolean bResult = false;

            Byte byRedLevel = 255;
            Byte byGreenLevel = 255;
            Byte byBlueLevel = 255;

            try
            {
                byRedLevel = Byte.Parse(textBoxRed.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease check Red color value. It should be a value from 0 to 255.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                byGreenLevel = Byte.Parse(textBoxGreen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease check Green color value. It should be a value from 0 to 255.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                byBlueLevel = Byte.Parse(textBoxBlue.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease check Blue color value. It should be a value from 0 to 255.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }

            bResult = _blynclightController.TurnRGBLedOn(nSelectedDeviceIndex, byRedLevel, byGreenLevel, byBlueLevel);

            if (!bResult)
            {
                MessageBox.Show("TurnOnRGBColors failed.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }           
        }

        private void comboBoxFlashSpeedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bySelectedFlashSpeed = (Byte)(comboBoxFlashSpeedList.SelectedIndex + 1);

            if (_blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
                _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
                _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
                _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 || 
                _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S ||
                _blynclightController.aoDevInfo[nSelectedDeviceIndex].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S)
            {
                // Select light flash speed
                bool bResult = _blynclightController.SelectLightFlashSpeed(nSelectedDeviceIndex, bySelectedFlashSpeed);
                if (bResult == false)
                {
                    MessageBox.Show("SelectLightFlashSpeed failed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void vScrollBarRed_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxRed.Text = vScrollBarRed.Value.ToString();
        }

        private void vScrollBarGreen_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxGreen.Text = vScrollBarGreen.Value.ToString();
        }

        private void vScrollBarBlue_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxBlue.Text = vScrollBarBlue.Value.ToString();
        }
    }
}