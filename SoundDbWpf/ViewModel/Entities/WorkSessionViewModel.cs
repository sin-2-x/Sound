using CommonWpf.ViewModel;
using System;
using SoundDatabase.DataModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public class WorkSessionViewModel : NotifyPropertyChanged, ITableEntityViewModel
    {
        private readonly WorkSession model;

        public WorkSessionViewModel(WorkSession model)
        {
            this.model = model;

        }

        public BaseEntity Model => model;
        public bool NeedApply { get; private set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
