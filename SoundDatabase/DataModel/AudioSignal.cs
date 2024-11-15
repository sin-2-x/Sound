namespace SoundDatabase.DataModel
{
    public class AudioSignal : BaseEntity
    {
        public string SoundFilePath { get; set; }
        public AnalyzeSession AnalyzeSession { get; set; }

        public DeviceWorkSession DeviceWorkSession { get; set; }
    }
}
