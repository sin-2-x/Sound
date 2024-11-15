using System;

namespace SoundDatabase.DataModel
{
    public class AnalyzeSessionResult:BaseEntity
    {
        public WorkSession WorkSession { get; set; }
        public DateTime Time { get; set; }

        public string Coords { get; set; }

    }
}
