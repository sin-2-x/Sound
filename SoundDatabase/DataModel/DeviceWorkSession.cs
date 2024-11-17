using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace SoundDatabase.DataModel
{
    public class DeviceWorkSession : BaseEntity
    {
        public WorkSession WorkSession { get; set; }

        public Guid? DeviceId { get; set; }
        public Device Device { get; set; }
        public List<AudioSignal> AudioSignals { get; set; }
    }
}
