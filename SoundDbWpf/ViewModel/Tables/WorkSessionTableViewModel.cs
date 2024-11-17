using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;

namespace SoundDbWpf.ViewModel.Tables
{
    public class WorkSessionTableViewModel : BaseTableViewModel<WorkSessionViewModel, WorkSession>, ITableViewModel
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
