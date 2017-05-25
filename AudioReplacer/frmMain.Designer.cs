namespace AudioReplacer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.cboMicDevice = new System.Windows.Forms.ComboBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.tmrUpdateVolume = new System.Windows.Forms.Timer(this.components);
            this.pbrMicValue = new wclDigaly.dyWin7Progress();
            this.lstInputfiles = new System.Windows.Forms.ListBox();
            this.btnSelectInput = new System.Windows.Forms.Button();
            this.lblInputPath = new System.Windows.Forms.Label();
            this.chkPlayOnSelect = new System.Windows.Forms.CheckBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPanic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboMicDevice
            // 
            this.cboMicDevice.FormattingEnabled = true;
            this.cboMicDevice.Location = new System.Drawing.Point(13, 13);
            this.cboMicDevice.Name = "cboMicDevice";
            this.cboMicDevice.Size = new System.Drawing.Size(259, 21);
            this.cboMicDevice.TabIndex = 0;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(279, 155);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(142, 23);
            this.btnRecord.TabIndex = 1;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // tmrUpdateVolume
            // 
            this.tmrUpdateVolume.Enabled = true;
            this.tmrUpdateVolume.Interval = 32;
            this.tmrUpdateVolume.Tick += new System.EventHandler(this.tmrUpdateVolume_Tick);
            // 
            // pbrMicValue
            // 
            this.pbrMicValue.BackColor = System.Drawing.Color.White;
            this.pbrMicValue.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.pbrMicValue.Location = new System.Drawing.Point(13, 40);
            this.pbrMicValue.Name = "pbrMicValue";
            this.pbrMicValue.Size = new System.Drawing.Size(259, 23);
            this.pbrMicValue.TabIndex = 3;
            this.pbrMicValue.Text = "dyWin7Progress1";
            this.pbrMicValue.Value = 0;
            // 
            // lstInputfiles
            // 
            this.lstInputfiles.FormattingEnabled = true;
            this.lstInputfiles.Location = new System.Drawing.Point(13, 126);
            this.lstInputfiles.Name = "lstInputfiles";
            this.lstInputfiles.Size = new System.Drawing.Size(260, 186);
            this.lstInputfiles.TabIndex = 4;
            this.lstInputfiles.SelectedIndexChanged += new System.EventHandler(this.lstInputfiles_SelectedIndexChanged);
            // 
            // btnSelectInput
            // 
            this.btnSelectInput.Location = new System.Drawing.Point(13, 97);
            this.btnSelectInput.Name = "btnSelectInput";
            this.btnSelectInput.Size = new System.Drawing.Size(259, 23);
            this.btnSelectInput.TabIndex = 5;
            this.btnSelectInput.Text = "Select input files directory";
            this.btnSelectInput.UseVisualStyleBackColor = true;
            this.btnSelectInput.Click += new System.EventHandler(this.btnSelectInput_Click);
            // 
            // lblInputPath
            // 
            this.lblInputPath.Location = new System.Drawing.Point(13, 319);
            this.lblInputPath.Name = "lblInputPath";
            this.lblInputPath.Size = new System.Drawing.Size(259, 42);
            this.lblInputPath.TabIndex = 6;
            this.lblInputPath.Text = "label1";
            // 
            // chkPlayOnSelect
            // 
            this.chkPlayOnSelect.AutoSize = true;
            this.chkPlayOnSelect.Location = new System.Drawing.Point(13, 74);
            this.chkPlayOnSelect.Name = "chkPlayOnSelect";
            this.chkPlayOnSelect.Size = new System.Drawing.Size(145, 17);
            this.chkPlayOnSelect.TabIndex = 7;
            this.chkPlayOnSelect.Text = "Play input files on select?";
            this.chkPlayOnSelect.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(279, 126);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(68, 23);
            this.btnPlay.TabIndex = 8;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPanic
            // 
            this.btnPanic.Location = new System.Drawing.Point(353, 126);
            this.btnPanic.Name = "btnPanic";
            this.btnPanic.Size = new System.Drawing.Size(68, 23);
            this.btnPanic.TabIndex = 9;
            this.btnPanic.Text = "Stop";
            this.btnPanic.UseVisualStyleBackColor = true;
            this.btnPanic.Click += new System.EventHandler(this.btnPanic_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 413);
            this.Controls.Add(this.btnPanic);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.chkPlayOnSelect);
            this.Controls.Add(this.lblInputPath);
            this.Controls.Add(this.btnSelectInput);
            this.Controls.Add(this.lstInputfiles);
            this.Controls.Add(this.pbrMicValue);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.cboMicDevice);
            this.Name = "frmMain";
            this.Text = "Audio Replacer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMicDevice;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Timer tmrUpdateVolume;
        private wclDigaly.dyWin7Progress pbrMicValue;
        private System.Windows.Forms.ListBox lstInputfiles;
        private System.Windows.Forms.Button btnSelectInput;
        private System.Windows.Forms.Label lblInputPath;
        private System.Windows.Forms.CheckBox chkPlayOnSelect;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPanic;
    }
}

