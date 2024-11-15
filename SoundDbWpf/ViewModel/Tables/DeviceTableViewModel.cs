using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;

namespace SoundDbWpf.ViewModel.Tables
{
    public class DeviceTableViewModel : TableViewModel<DeviceViewModel, Device>
    {
        public DeviceTableViewModel() : base(new DevicesTable(), TableEnum.Device)
        {
        }

        protected override DeviceViewModel CreateViewModel(Device e)
        {
            return new DeviceViewModel(e);
        }
    }
}
