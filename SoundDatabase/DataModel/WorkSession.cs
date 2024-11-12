using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDatabase.DataModel
{
    public class WorkSession :BaseEntity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeStop { get; set; }
        public List<DeviceWorkSession> DeviceWorkSessions { get; set; }
        public List<AnalyzeSessionResult> AnalyzeSessionResults { get; set; }
    }
}
