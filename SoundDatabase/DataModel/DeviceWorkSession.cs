using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDatabase.DataModel
{
    public class DeviceWorkSession : BaseEntity
    {
        public WorkSession WorkSession { get; set; }
        public Device Device { get; set; }
        public List<AudioSignal> AudioSignals { get; set; }
    }
}
