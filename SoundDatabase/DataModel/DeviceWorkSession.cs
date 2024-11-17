using System;
using System.Collections.Generic;

namespace SoundDatabase.DataModel
{
    public class DeviceWorkSession : BaseEntity
    {
        public Guid? WorkSessionId { get; set; }
        public WorkSession WorkSession { get; set; }

        public Guid? DeviceId { get; set; }
        public Device Device { get; set; }
        public List<AudioSignal> AudioSignals { get; set; }
    }
}
