using System;

namespace SoundDatabase.DataModel
{
    public class AnalyzeSession:BaseEntity
    {
        public AnalyzeSessionResult AnalyzeSessionResult { get; set; }

        public Guid AudioSignalId { get; set; }
        public AudioSignal AudioSignal { get; set; }
    }
}
