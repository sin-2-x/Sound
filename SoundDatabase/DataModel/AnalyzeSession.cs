using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDatabase.DataModel
{
    public class AnalyzeSession:BaseEntity
    {
        public AnalyzeSessionResult AnalyzeSessionResult { get; set; }
        public AudioSignal AudioSignal { get; set; }
    }
}
