using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoundDbWpf.ViewModel.Tables
{
    public interface ITableViewModel
    {
        TableEnum TableEnum { get; }
        void UpdateImpl();

        void AddImpl();

        void RemoveImpl();

        void SaveImpl();

    }

    public abstract class TableViewModel<T, M> : ITableViewModel where M : BaseEntity where T : ITableEntityViewModel
    {
        protected BaseTable<M> model;

        protected List<T> addedItems = new List<T>();
        protected List<T> removeditems = new List<T>();

        protected TableViewModel(BaseTable<M> model, TableEnum tableEnum)
        {
            this.model = model;
            TableEnum = tableEnum;  
        }

        public TableEnum TableEnum { get; }

        public T SelectedItem { get; set; }

        public ObservableCollection<T> Items { get; set; } = new ObservableCollection<T>();

        protected abstract T CreateViewModel(M model);

        public void AddImpl()
        {
            M model1 = model.CreateNewEntity();
            var newItem = CreateViewModel(model1);
            Items.Add(newItem);
            addedItems.Add(newItem);
        }

        public void RemoveImpl()
        {
            if (SelectedItem == null)
            {
                return;
            }
            removeditems.Add(SelectedItem);
            Items.Remove(SelectedItem);


        }

        public void UpdateImpl()
        {
            addedItems.Clear();
            removeditems.Clear();

            var collection = model.GetEntries();

            Items.Clear();
            foreach (var device in collection)
            {
                Items.Add(CreateViewModel(device));
            }
            SelectedItem = Items.FirstOrDefault();
        }

        public void SaveImpl()
        {
            model.UpdateEntries(addedItems.Select(i => i.Model).ToList(), removeditems.Select(i => i.Model).ToList(), Items.Where(i => i.NeedApply).Select(i => i.Model).ToList());

            addedItems.Clear();
            removeditems.Clear();
        }

    }

    /*public interface TableViewModel<T>
    {
        T SelectedItem { get; set; }

        ObservableCollection<T> Items { get; }
    }*/
    /*
        public class AnalyzeSessionResultTableViewModel : TableViewModel<AnalyzeSessionResultViewModel>, ITableViewModel
        {
            public AnalyzeSessionResultTableViewModel(SoundDbModel.SoundDbModel model) : base(model)
            {
            }

            public TableEnum TableEnum => TableEnum.AnalyzeSessionResult;
            public void Update()
            {

            }
        }
        public class AnalyzeSessionTableViewModel : TableViewModel<AnalyzeSessionViewModel>, ITableViewModel
        {
            public AnalyzeSessionTableViewModel(SoundDbModel.SoundDbModel model) : base(model)
            {
            }
            public TableEnum TableEnum => TableEnum.AnalyzeSession;
            public void Update()
            {
                throw new NotImplementedException();
            }
        }
        public class AudioSignalTableViewModel : TableViewModel<AudioSignalViewModel>, ITableViewModel
        {
            public AudioSignalTableViewModel(SoundDbModel.SoundDbModel model) : base(model)
            {
            }
            public TableEnum TableEnum => TableEnum.AudioSignal;
            public void Update()
            {
            }
        }

        public class DeviceWorkSessionTableViewModel : TableViewModel<DeviceWorkSessionViewModel>, ITableViewModel
        {
            public DeviceWorkSessionTableViewModel(SoundDbModel.SoundDbModel model) : base(model)
            {
            }
            public TableEnum TableEnum => TableEnum.DeviceWorkSession;
            public void Update()
            {
            }
        }*/

}
