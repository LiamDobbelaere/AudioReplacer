using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace AudioReplacer
{
    class MicDeviceWrapper
    {
        public MicDeviceWrapper(int number, MMDevice device)
        {
            this.Number = number;
            this.Device = device;
        }

        public int Number { get; set; }

        public MMDevice Device { get; set; }

        public override string ToString()
        {
            return Device.FriendlyName;
        }
    }
}
