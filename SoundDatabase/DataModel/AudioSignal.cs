using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDatabase.DataModel
{
    public class AudioSignal : BaseEntity
    {
        public string SoundFilePath { get; set; }
        public AnalyzeSession AnalyzeSession { get; set; }

        public DeviceWorkSession DeviceWorkSession { get; set; }
    }
}
