using CommonWpf.ViewModel;
using SoundDatabase;
using SoundDatabase.DataModel;
using SoundDbWpf.ViewModel.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbWpf.ViewModel.Tables
{
    public interface ITableViewModel
    {
        TableEnum TableEnum { get; }
        void UpdateTable();

        ITableEntityViewModel GetNewItem();
        ITableEntityViewModel GetSelectedItem();

    }

    public abstract class TableViewModel<T,M>
    {
        protected SoundDbModel.SoundDbModel model;

        protected TableViewModel(SoundDbModel.SoundDbModel model)
        {
            this.model = model;
        }
        public T SelectedItem { get; set; }

        public ObservableCollection<T> Items { get; set; } = new ObservableCollection<T>();

        protected abstract T CreateViewModel(M model );

        protected abstract IEnumerable<M> GetModels();

        public void UpdateTable()
        {
            var collection = GetModels();

            Items.Clear();
            foreach (var device in collection)
            {
                Items.Add(CreateViewModel(device));
            }
            SelectedItem = Items.FirstOrDefault();
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
