using CommonWpf.ViewModel;
using SoundDbWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundDbWpf.ViewModel.Tables;

namespace SoundDbWpf.ViewModel.Entities
{
    public class DeviceWorkSessionViewModel : NotifyPropertyChanged
    {
        public TableEnum TableEnum => TableEnum.DeviceWorkSession;
    }
}
