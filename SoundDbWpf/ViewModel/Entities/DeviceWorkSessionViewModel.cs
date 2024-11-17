using CommonWpf.ViewModel;
using SoundDatabase.DataModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public class DeviceWorkSessionViewModel : NotifyPropertyChanged, ITableEntityViewModel<DeviceWorkSession>
    {
        private readonly DeviceWorkSession model;

        private DeviceViewModel device;
        private WorkSessionViewModel workSession;
        public DeviceWorkSessionViewModel(DeviceWorkSession model)
        {
            this.model = model;
        }

        public TableEnum TableEnum => TableEnum.DeviceWorkSession;
        public DeviceWorkSession Model => model;
        public bool NeedApply { get; private set; }

        public DeviceViewModel Device
        {
            get
            {
                return device;
            }
            set
            {
                if (value == device)
                {
                    return;
                }
                NeedApply = true;
                device = value;

                model.DeviceId = device?.Model.Id;
            }
        }

        public WorkSessionViewModel WorkSession
        {
            get
            {
                return workSession;
            }
            set
            {
                if (value == workSession)
                {
                    return;
                }
                NeedApply = true;
                workSession = value;

                model.WorkSessionId = workSession?.Model.Id;
            }
        }
    }
}
