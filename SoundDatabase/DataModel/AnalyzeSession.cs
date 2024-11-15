namespace SoundDatabase.DataModel
{
    public class AnalyzeSession:BaseEntity
    {
        public AnalyzeSessionResult AnalyzeSessionResult { get; set; }
        public AudioSignal AudioSignal { get; set; }
    }
}
