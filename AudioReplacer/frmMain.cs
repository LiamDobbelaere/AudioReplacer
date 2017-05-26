using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace AudioReplacer
{
    public partial class frmMain : Form
    {
        private bool recording = false;
        private WaveIn waveSource = null;
        private WaveOut playback = null;
        private WaveFileWriter waveFile = null;
        private WaveFileReader wfr = null;
        private CommonOpenFileDialog dialog = new CommonOpenFileDialog();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dialog.IsFolderPicker = true;

            playback = new WaveOut();

            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            MMDevice[] devicesArray = devices.ToArray();

            for (int i = 0; i < devicesArray.Length; i++)
            {
                MMDevice device = devicesArray[i];

                cboMicDevice.Items.Add(new MicDeviceWrapper(i, device));
            }

            /*int waveInDevices = WaveIn.DeviceCount;

            for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                MicDeviceWrapper micWrapper = new MicDeviceWrapper(waveInDevice, deviceInfo);

                

                cboMicDevice.Items.Add(micWrapper);
            }*/

            if (cboMicDevice.Items.Count > 0) cboMicDevice.SelectedIndex = 0;

            btnRecord.BackColor = Color.White;
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                btnRecord.BackColor = Color.White;
                btnRecord.ForeColor = Color.Black;

                waveSource.StopRecording();

                recording = false;
            }
            else
            {
                stopSounds();

                if (lstInputfiles.SelectedItem != null)
                {
                    btnRecord.BackColor = Color.Red;
                    btnRecord.ForeColor = Color.White;

                    waveSource = new WaveIn();
                    waveSource.DeviceNumber = ((MicDeviceWrapper)cboMicDevice.SelectedItem).Number;
                    waveSource.WaveFormat = new WaveFormat(44100, 1);

                    waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                    waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

                    waveFile = new WaveFileWriter(Path.Combine(lblInputPath.Text, lstInputfiles.SelectedItem.ToString()), waveSource.WaveFormat);

                    waveSource.StartRecording();

                    recording = true;
                }
            }
        }

        private void tmrUpdateVolume_Tick(object sender, EventArgs e)
        {
            if (cboMicDevice.SelectedItem != null)
            {
                MMDevice device = ((MicDeviceWrapper)cboMicDevice.SelectedItem).Device;
                pbrMicValue.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
            }
        }

        private void btnSelectInput_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                lstInputfiles.Items.Clear();

                string path = dialog.FileName;
                string[] filePaths = Directory.GetFiles(path, "*.wav");

                lblInputPath.Text = path;

                foreach (string wavPath in filePaths)
                {
                    lstInputfiles.Items.Add(Path.GetFileName(wavPath));
                }
            }
        }

        private void playSelectedInputSound()
        {
            if (playback != null) playback.Dispose();
            if (wfr != null) wfr.Dispose();

            if (lstInputfiles.SelectedItem == null) return;

            playback = new WaveOut();
            wfr = new WaveFileReader(Path.Combine(lblInputPath.Text, lstInputfiles.SelectedItem.ToString()));
            playback.Init(wfr);
            playback.Play();

            tmrUpdatePlayback.Start();
        }

        private void lstInputfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkPlayOnSelect.Checked) playSelectedInputSound();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            playSelectedInputSound();
        }

        private void btnPanic_Click(object sender, EventArgs e)
        {
            stopSounds();
        }

        private void stopSounds()
        {
            tmrUpdatePlayback.Stop();

            if (playback != null) playback.Dispose();
            if (wfr != null) wfr.Dispose();
        }

        private void tmrUpdatePlayback_Tick(object sender, EventArgs e)
        {
            if (wfr != null)
            {
                int targetValue = (int)(Math.Round(wfr.CurrentTime.TotalMilliseconds / wfr.TotalTime.TotalMilliseconds * 100));

                if (targetValue > 80) pbrWaveProgress.ForeColor = Color.Red;
                else if (targetValue > 50) pbrWaveProgress.ForeColor = Color.Orange;
                else pbrWaveProgress.ForeColor = Color.Green;

                pbrWaveProgress.Value = targetValue;
            }
        }
    }
}
