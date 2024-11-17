using CommonWpf;
using SoundDatabase.DataModel;
using SoundDbModel.Tables;
using SoundDbWpf.ViewModel.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

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
            var newModel = model.CreateNewEntity();
            var newViewModel = CreateViewModel(newModel);

            addedItems.Add(newModel);

            MainApplication.BeginInvokeInGuiThread(() =>
            {
                Items.Add(newViewModel);
            });

        }

        public void RemoveImpl()
        {
            if (SelectedItem == null)
            {
                return;
            }

            removeditems.Add(SelectedItem.Model);

            MainApplication.BeginInvokeInGuiThread(() =>
            {
                Items.Remove(SelectedItem);
            });
        }

        public virtual void UpdateImpl()
        {
            addedItems.Clear();
            removeditems.Clear();
            var models = model.GetEntries();
            var viewModels = models.Select(m=> CreateViewModel(m));

            UpdateItems(viewModels);
        }

        private void UpdateItems(IEnumerable<T> vms)
        {
            if (MainApplication.InvokeRequired)
            {
                MainApplication.BeginInvokeInGuiThread(() => UpdateItems(vms));
                return;
            }

            Items.Clear();
            foreach (var vm in vms)
            {
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
