using System.Collections.Generic;

namespace SoundDatabase.DataModel
{
    public class DeviceWorkSession : BaseEntity
    {
        public WorkSession WorkSession { get; set; }
        public Device Device { get; set; }
        public List<AudioSignal> AudioSignals { get; set; }
    }
}
