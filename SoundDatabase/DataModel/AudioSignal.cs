using System;

namespace SoundDatabase.DataModel
{
    public class AudioSignal : BaseEntity
    {
        public string SoundFilePath { get; set; }

        public Guid? AnalyzeSessionId { get; set; }
        public AnalyzeSession AnalyzeSession { get; set; }

        public Guid? DeviceWorkSessionId { get; set; }
        public DeviceWorkSession DeviceWorkSession { get; set; }
    }
}
