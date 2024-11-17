using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbWpf.ViewModel.Tables
{

    public class DeviceWorkSessionTableViewModel : TableViewModel<DeviceWorkSessionViewModel, DeviceWorkSession>
    {
        DeviceTableViewModel devices; WorkSessionTableViewModel workSessions;

        public DeviceWorkSessionTableViewModel(DeviceTableViewModel d, WorkSessionTableViewModel workSessions) : base(new DeviceWorkSessionTable(), TableEnum.DeviceWorkSession)
        {
            this.devices = d;
            this.workSessions = workSessions;
        }

        protected override DeviceWorkSessionViewModel CreateViewModel(DeviceWorkSession e)
        {
            var vm = new DeviceWorkSessionViewModel(e);
            vm.Device = Devices.FirstOrDefault(d => d.Model.Id == e.DeviceId);
            return vm;
        }
        public ObservableCollection<DeviceViewModel> Devices => devices.Items;
        public ObservableCollection<WorkSessionViewModel> WorkSessions => workSessions.Items;

        public override void UpdateImpl()
        {
            devices.UpdateImpl();
            workSessions.UpdateImpl();
            base.UpdateImpl();
        }
    }
}
