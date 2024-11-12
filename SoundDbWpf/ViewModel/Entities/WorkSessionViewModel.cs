using CommonWpf.ViewModel;
using SoundDbWpf.ViewModel.Entities;
using SoundDbWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundDatabase.DataModel;
using System.Windows.Input;

namespace SoundDbWpf.ViewModel.Entities
{
    public class WorkSessionViewModel : NotifyPropertyChanged, ITableEntityViewModel
    {
        private WorkSession model;

        public WorkSessionViewModel(WorkSession model)
        {
            this.model = model;

            UpdateFromModel();

            ApplyCommand = new ActionCommand(o => { UpdateModel(); });
        }

        public ICommand ApplyCommand { get; }


        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public void UpdateFromModel()
        {
            StartTime = model.TimeStart;
            EndTime = model.TimeStop;
        }

        public void UpdateModel()
        {
            model.TimeStart = StartTime;
            model.TimeStop = EndTime;
        }
    }
}
