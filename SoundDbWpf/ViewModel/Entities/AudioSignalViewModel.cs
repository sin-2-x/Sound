using CommonWpf.ViewModel;
using SoundDatabase.DataModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public class AudioSignalViewModel : NotifyPropertyChanged, ITableEntityViewModel<AudioSignal>
    {
        private DeviceWorkSessionViewModel deviceWorkSession;
        public AudioSignalViewModel(AudioSignal model)
        {
            Model = model;
        }

        public DeviceWorkSessionViewModel DeviceWorkSession
        {
            get { return deviceWorkSession; }
            set
            {
                if (value == deviceWorkSession)
                {
                    return;
                }
                NeedApply = true;
                deviceWorkSession = value;

                Model.DeviceWorkSessionId = deviceWorkSession?.Model.Id;
            }
        }
        public bool NeedApply { get; private set; }

        public AudioSignal Model { get; }
    }
}
