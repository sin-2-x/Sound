using SoundDatabase.DataModel;
using SoundDbWpf.ViewModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbWpf.ViewModel.Tables
{
    public class WorkSessionTableViewModel : TableViewModel<WorkSessionViewModel, WorkSession>, ITableViewModel
    {
        public WorkSessionTableViewModel(SoundDbModel.SoundDbModel model) : base(model)
        {
        }

        public TableEnum TableEnum => TableEnum.WorkSession;

        public ITableEntityViewModel GetNewItem()
        {
            return new WorkSessionViewModel(new WorkSession());
        }

        public ITableEntityViewModel GetSelectedItem()
        {
            return SelectedItem;
        }

        protected override WorkSessionViewModel CreateViewModel(WorkSession e)
        {
            return new WorkSessionViewModel(e);
        }

        protected override IEnumerable<WorkSession> GetModels()
        {
            return model.GetWorlSessions();
        }
    }
}
