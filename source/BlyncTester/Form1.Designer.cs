namespace BlyncTester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxLightControls = new System.Windows.Forms.GroupBox();
            this.buttonSetRgbValues = new System.Windows.Forms.Button();
            this.comboBoxFlashSpeedList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxFlashLight = new System.Windows.Forms.CheckBox();
            this.checkBoxDimLight = new System.Windows.Forms.CheckBox();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.textBoxBlue = new System.Windows.Forms.TextBox();
            this.vScrollBarBlue = new System.Windows.Forms.VScrollBar();
            this.textBoxGreen = new System.Windows.Forms.TextBox();
            this.vScrollBarGreen = new System.Windows.Forms.VScrollBar();
            this.checkBoxDisplayLight = new System.Windows.Forms.CheckBox();
            this.textBoxRed = new System.Windows.Forms.TextBox();
            this.vScrollBarRed = new System.Windows.Forms.VScrollBar();
            this.groupBoxNewDeviceControls = new System.Windows.Forms.GroupBox();
            this.groupBoxLightControls.SuspendLayout();
            this.groupBoxNewDeviceControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLightControls
            // 
            this.groupBoxLightControls.Controls.Add(this.buttonSetRgbValues);
            this.groupBoxLightControls.Controls.Add(this.comboBoxFlashSpeedList);
            this.groupBoxLightControls.Controls.Add(this.label2);
            this.groupBoxLightControls.Controls.Add(this.checkBoxFlashLight);
            this.groupBoxLightControls.Controls.Add(this.checkBoxDimLight);
            this.groupBoxLightControls.Controls.Add(this.labelBlue);
            this.groupBoxLightControls.Controls.Add(this.labelGreen);
            this.groupBoxLightControls.Controls.Add(this.labelRed);
            this.groupBoxLightControls.Controls.Add(this.textBoxBlue);
            this.groupBoxLightControls.Controls.Add(this.vScrollBarBlue);
            this.groupBoxLightControls.Controls.Add(this.textBoxGreen);
            this.groupBoxLightControls.Controls.Add(this.vScrollBarGreen);
            this.groupBoxLightControls.Controls.Add(this.checkBoxDisplayLight);
            this.groupBoxLightControls.Controls.Add(this.textBoxRed);
            this.groupBoxLightControls.Controls.Add(this.vScrollBarRed);
            this.groupBoxLightControls.Location = new System.Drawing.Point(9, 14);
            this.groupBoxLightControls.Name = "groupBoxLightControls";
            this.groupBoxLightControls.Size = new System.Drawing.Size(300, 137);
            this.groupBoxLightControls.TabIndex = 22;
            this.groupBoxLightControls.TabStop = false;
            // 
            // buttonSetRgbValues
            // 
            this.buttonSetRgbValues.Location = new System.Drawing.Point(215, 54);
            this.buttonSetRgbValues.Name = "buttonSetRgbValues";
            this.buttonSetRgbValues.Size = new System.Drawing.Size(77, 23);
            this.buttonSetRgbValues.TabIndex = 32;
            this.buttonSetRgbValues.Text = "Set";
            this.buttonSetRgbValues.UseVisualStyleBackColor = true;
            this.buttonSetRgbValues.Click += new System.EventHandler(this.buttonSetRgbValues_Click);
            // 
            // comboBoxFlashSpeedList
            // 
            this.comboBoxFlashSpeedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlashSpeedList.FormattingEnabled = true;
            this.comboBoxFlashSpeedList.Items.AddRange(new object[] {
            "Slow",
            "Med",
            "Fast"});
            this.comboBoxFlashSpeedList.Location = new System.Drawing.Point(215, 104);
            this.comboBoxFlashSpeedList.Name = "comboBoxFlashSpeedList";
            this.comboBoxFlashSpeedList.Size = new System.Drawing.Size(77, 21);
            this.comboBoxFlashSpeedList.TabIndex = 28;
            this.comboBoxFlashSpeedList.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlashSpeedList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Speed";
            // 
            // checkBoxFlashLight
            // 
            this.checkBoxFlashLight.AutoSize = true;
            this.checkBoxFlashLight.Location = new System.Drawing.Point(79, 106);
            this.checkBoxFlashLight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxFlashLight.Name = "checkBoxFlashLight";
            this.checkBoxFlashLight.Size = new System.Drawing.Size(77, 17);
            this.checkBoxFlashLight.TabIndex = 23;
            this.checkBoxFlashLight.Text = "Flash Light";
            this.checkBoxFlashLight.UseVisualStyleBackColor = true;
            this.checkBoxFlashLight.CheckedChanged += new System.EventHandler(this.checkBoxFlashLight_CheckedChanged);
            // 
            // checkBoxDimLight
            // 
            this.checkBoxDimLight.AutoSize = true;
            this.checkBoxDimLight.Location = new System.Drawing.Point(8, 106);
            this.checkBoxDimLight.Name = "checkBoxDimLight";
            this.checkBoxDimLight.Size = new System.Drawing.Size(70, 17);
            this.checkBoxDimLight.TabIndex = 10;
            this.checkBoxDimLight.Text = "Dim Light";
            this.checkBoxDimLight.UseVisualStyleBackColor = true;
            this.checkBoxDimLight.CheckedChanged += new System.EventHandler(this.checkBoxDimLight_CheckedChanged);
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(150, 38);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 13);
            this.labelBlue.TabIndex = 9;
            this.labelBlue.Text = "Blue";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(76, 38);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 8;
            this.labelGreen.Text = "Green";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(5, 38);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 7;
            this.labelRed.Text = "Red";
            // 
            // textBoxBlue
            // 
            this.textBoxBlue.Location = new System.Drawing.Point(153, 55);
            this.textBoxBlue.Name = "textBoxBlue";
            this.textBoxBlue.Size = new System.Drawing.Size(40, 20);
            this.textBoxBlue.TabIndex = 6;
            this.textBoxBlue.Text = "255";
            // 
            // vScrollBarBlue
            // 
            this.vScrollBarBlue.Location = new System.Drawing.Point(196, 52);
            this.vScrollBarBlue.Maximum = 264;
            this.vScrollBarBlue.Name = "vScrollBarBlue";
            this.vScrollBarBlue.Size = new System.Drawing.Size(17, 24);
            this.vScrollBarBlue.TabIndex = 5;
            this.vScrollBarBlue.Value = 255;
            this.vScrollBarBlue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarBlue_Scroll);
            // 
            // textBoxGreen
            // 
            this.textBoxGreen.Location = new System.Drawing.Point(79, 54);
            this.textBoxGreen.Name = "textBoxGreen";
            this.textBoxGreen.Size = new System.Drawing.Size(40, 20);
            this.textBoxGreen.TabIndex = 4;
            this.textBoxGreen.Text = "255";
            // 
            // vScrollBarGreen
            // 
            this.vScrollBarGreen.Location = new System.Drawing.Point(122, 52);
            this.vScrollBarGreen.Maximum = 264;
            this.vScrollBarGreen.Name = "vScrollBarGreen";
            this.vScrollBarGreen.Size = new System.Drawing.Size(17, 24);
            this.vScrollBarGreen.TabIndex = 3;
            this.vScrollBarGreen.Value = 255;
            this.vScrollBarGreen.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarGreen_Scroll);
            // 
            // checkBoxDisplayLight
            // 
            this.checkBoxDisplayLight.AutoSize = true;
            this.checkBoxDisplayLight.Location = new System.Drawing.Point(8, 14);
            this.checkBoxDisplayLight.Name = "checkBoxDisplayLight";
            this.checkBoxDisplayLight.Size = new System.Drawing.Size(86, 17);
            this.checkBoxDisplayLight.TabIndex = 2;
            this.checkBoxDisplayLight.Text = "Display Light";
            this.checkBoxDisplayLight.UseVisualStyleBackColor = true;
            this.checkBoxDisplayLight.CheckedChanged += new System.EventHandler(this.checkBoxDisplayLight_CheckedChanged);
            // 
            // textBoxRed
            // 
            this.textBoxRed.Location = new System.Drawing.Point(8, 54);
            this.textBoxRed.Name = "textBoxRed";
            this.textBoxRed.Size = new System.Drawing.Size(39, 20);
            this.textBoxRed.TabIndex = 1;
            this.textBoxRed.Text = "255";
            // 
            // vScrollBarRed
            // 
            this.vScrollBarRed.Location = new System.Drawing.Point(48, 51);
            this.vScrollBarRed.Maximum = 264;
            this.vScrollBarRed.Name = "vScrollBarRed";
            this.vScrollBarRed.Size = new System.Drawing.Size(17, 24);
            this.vScrollBarRed.TabIndex = 0;
            this.vScrollBarRed.Value = 255;
            this.vScrollBarRed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarRed_Scroll);
            // 
            // groupBoxNewDeviceControls
            // 
            this.groupBoxNewDeviceControls.Controls.Add(this.groupBoxLightControls);
            this.groupBoxNewDeviceControls.Location = new System.Drawing.Point(12, 12);
            this.groupBoxNewDeviceControls.Name = "groupBoxNewDeviceControls";
            this.groupBoxNewDeviceControls.Size = new System.Drawing.Size(316, 157);
            this.groupBoxNewDeviceControls.TabIndex = 32;
            this.groupBoxNewDeviceControls.TabStop = false;
            this.groupBoxNewDeviceControls.Text = "BlyncUSB30/30S/Mini/Headset Devices";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 173);
            this.Controls.Add(this.groupBoxNewDeviceControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Blync Light Test Software";
            this.groupBoxLightControls.ResumeLayout(false);
            this.groupBoxLightControls.PerformLayout();
            this.groupBoxNewDeviceControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxLightControls;
        private System.Windows.Forms.VScrollBar vScrollBarRed;
        private System.Windows.Forms.TextBox textBoxRed;
        private System.Windows.Forms.CheckBox checkBoxDisplayLight;
        private System.Windows.Forms.TextBox textBoxBlue;
        private System.Windows.Forms.VScrollBar vScrollBarBlue;
        private System.Windows.Forms.TextBox textBoxGreen;
        private System.Windows.Forms.VScrollBar vScrollBarGreen;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.CheckBox checkBoxFlashLight;
        private System.Windows.Forms.CheckBox checkBoxDimLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFlashSpeedList;
        private System.Windows.Forms.Button buttonSetRgbValues;
        private System.Windows.Forms.GroupBox groupBoxNewDeviceControls;
    }
}

