using CommonWpf.ViewModel;
using SoundDbWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundDbWpf.ViewModel.Tables;
using SoundDatabase.DataModel;
using System.Collections.ObjectModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public class DeviceWorkSessionViewModel : NotifyPropertyChanged, ITableEntityViewModel<DeviceWorkSession>
    {
        private readonly DeviceWorkSession model;

        private DeviceViewModel device;
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
                model.Device = device.Model;
                model.DeviceId = device.Model.Id;
            }
        }

        public WorkSession WorkSession
        {
            get
            {
                return model.WorkSession;
            }
            set
            {
                if (value == model.WorkSession)
                {
                    return;
                }
                NeedApply = true;
                model.WorkSession = value;
            }
        }
    }
}
