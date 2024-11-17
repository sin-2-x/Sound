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

    public abstract class BaseTableViewModel<T, M> : ITableViewModel where M : BaseEntity where T : ITableEntityViewModel<M>
    {
        protected BaseTable<M> model;

        protected List<M> addedItems = new List<M>();
        protected List<M> removeditems = new List<M>();

        protected BaseTableViewModel(BaseTable<M> model, TableEnum tableEnum)
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
            var newEntity = model.CreateNewEntity();
            var newItem = CreateViewModel(newEntity);

            Items.Add(newItem);
            addedItems.Add(newEntity);
        }

        public void RemoveImpl()
        {
            if (SelectedItem == null)
            {
                return;
            }
            removeditems.Add(SelectedItem.Model);
            Items.Remove(SelectedItem);
        }

        public virtual void UpdateImpl()
        {
            addedItems.Clear();
            removeditems.Clear();
            Items.Clear();

            var collection = model.GetEntries();
            foreach (var device in collection)
            {
                var vm = CreateViewModel(device);
                Items.Add(vm);
            }
            SelectedItem = Items.FirstOrDefault();
        }

        public void SaveImpl()
        {
            model.UpdateEntries(addedItems.ToList(), removeditems.ToList(), Items.Where(i => i.NeedApply).Select(i => i.Model).ToList());
        }
    }
}
