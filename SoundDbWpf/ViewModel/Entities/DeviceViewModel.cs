using CommonWpf.ViewModel;
using SoundDbWpf.ViewModel.Entities;
using SoundDbWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using SoundDatabase.DataModel;
using System.Windows.Input;

namespace SoundDbWpf.ViewModel.Entities
{
    public class DeviceViewModel : NotifyPropertyChanged, ITableEntityViewModel
    {
        private Device model;
        public DeviceViewModel(Device model) {
            this.model = model;

            Name = model.Name;
        }

        public string Name {get;set;}

        public ICommand ApplyCommand { get; }
    }
}
