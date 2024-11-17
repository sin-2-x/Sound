using CommonWpf.ViewModel;
using System;
using SoundDatabase.DataModel;

namespace SoundDbWpf.ViewModel.Entities
{
    public class WorkSessionViewModel : NotifyPropertyChanged, ITableEntityViewModel<WorkSession>
    {
        private readonly WorkSession model;

        public WorkSessionViewModel(WorkSession model)
        {
            this.model = model;

        }

        public WorkSession Model => model;
        public bool NeedApply { get; private set; }

        public DateTime StartTime
        {
            get
            {
                return model.TimeStart;
            }
            set
            {
                if (value == model.TimeStart)
                {
                    return;
                }
                NeedApply = true;
                model.TimeStart = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return model.TimeStop;
            }
            set
            {
                if (value == model.TimeStop)
                {
                    return;
                }
                NeedApply = true;
                model.TimeStop = value;
            }
        }

        public override string ToString()
        {

            return string.Concat(StartTime.ToString("dd.MM.yyyy HH:mm"), " - ", EndTime.ToString("dd.MM.yyyy HH:mm"));
        }
    }
}
