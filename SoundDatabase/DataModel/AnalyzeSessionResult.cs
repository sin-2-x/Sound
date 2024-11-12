using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDatabase.DataModel
{
    public class AnalyzeSessionResult:BaseEntity
    {
        public WorkSession WorkSession { get; set; }
        public DateTime Time { get; set; }

        public string Coords { get; set; }

    }
}
