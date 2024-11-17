using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoundDbWpf.ViewModel.Tables
{

    public class DeviceWorkSessionTableViewModel : BaseTableViewModel<DeviceWorkSessionViewModel, DeviceWorkSession>
    {
        DeviceTableViewModel devices; WorkSessionTableViewModel workSessions;

        public DeviceWorkSessionTableViewModel(DeviceTableViewModel d, WorkSessionTableViewModel workSessions) : base(new DeviceWorkSessionTable(), TableEnum.DeviceWorkSession)
        {
            this.devices = d;
            this.workSessions = workSessions;
        }

        public ObservableCollection<DeviceViewModel> Devices => devices.Items;
        public ObservableCollection<WorkSessionViewModel> WorkSessions => workSessions.Items;

        public override void UpdateImpl()
        {
            devices.UpdateImpl();
            workSessions.UpdateImpl();
            base.UpdateImpl();
        }

        protected override DeviceWorkSessionViewModel CreateViewModel(DeviceWorkSession model)
        {
            var vm = new DeviceWorkSessionViewModel(model)
            {
                Device = Devices.FirstOrDefault(d => d.Model.Id == model.DeviceId),
                WorkSession = WorkSessions.FirstOrDefault(d => d.Model.Id == model.WorkSessionId)
            };
            return vm;
        }
    }
}
