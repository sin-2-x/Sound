using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoundDbWpf.ViewModel.Tables
{
    public class WorkSessionTableViewModel : TableViewModel<WorkSessionViewModel, WorkSession>, ITableViewModel
    {
        public WorkSessionTableViewModel() : base(new WorkSessionsTable(), TableEnum.WorkSession)
        {
        }

        protected override WorkSessionViewModel CreateViewModel(WorkSession e)
        {
            return new WorkSessionViewModel(e);
        }

        
    }
}
