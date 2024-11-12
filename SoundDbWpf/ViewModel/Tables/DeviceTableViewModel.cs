using SoundDatabase.DataModel;
using SoundDbWpf.ViewModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbWpf.ViewModel.Tables
{
    public class DeviceTableViewModel : TableViewModel<DeviceViewModel, Device>, ITableViewModel
    {
        public DeviceTableViewModel(SoundDbModel.SoundDbModel model) : base(model)
        {
        }

        public TableEnum TableEnum => TableEnum.Device;


        public ITableEntityViewModel GetNewItem()
        {
            return new DeviceViewModel(new Device());
        }

        public ITableEntityViewModel GetSelectedItem()
        {
            return SelectedItem;
        }



        protected override DeviceViewModel CreateViewModel(Device e)
        {
            return new DeviceViewModel(e);
        }

        protected override IEnumerable<Device> GetModels()
        {
            return model.GetDevices();
        }


    }
}
