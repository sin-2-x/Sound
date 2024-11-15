using CommonWpf.ViewModel;
using SoundDatabase.DataModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public class DeviceViewModel : NotifyPropertyChanged, ITableEntityViewModel
    {
        private readonly Device model;

        public DeviceViewModel(Device model)
        {
            this.model = model;
        }

        public BaseEntity Model => model;

        public bool NeedApply { get; private set; }

        public string Name
        {
            get
            {
                return model.Name;
            }
            set
            {
                if (value == model.Name)
                {
                    return;
                }
                NeedApply = true;
                model.Name = value;
            }
        }
    }
}
