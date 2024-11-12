using CommonWpf.ViewModel;
using SoundDbWpf.Theme;
using SoundDbWpf.ViewModel.Entities;
using SoundDbWpf.ViewModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace SoundDbWpf.ViewModel
{
    internal class SoundDbViewModel : NotifyPropertyChanged
    {
        private readonly ITheme theme;
        private SoundDbModel.SoundDbModel model;

        private ITableViewModel selectedTable;
        public SoundDbViewModel(SoundDbModel.SoundDbModel model, ITheme theme)
        {
            this.theme = theme;
            this.model = model;

            Tables = new List<ITableViewModel> {
                new DeviceTableViewModel(model),
                /*new AnalyzeSessionResultTableViewModel(model),
                new AnalyzeSessionTableViewModel(model),
                new AudioSignalTableViewModel(model),
                new DeviceWorkSessionTableViewModel(model),*/
                new WorkSessionTableViewModel(model)
            };

            ApplyCommand = new ActionCommand(o => {


                //AddEntity?.Invoke(selectedTable.GetNewItem());
                SelectedTable.GetSelectedItem().UpdateModel();
                model.Save();


            });

            RemoveCommand = new ActionCommand(o => {

                SelectedTable.GetSelectedItem().UpdateFromModel();
            });
        }

        public byte[] AddIcon => theme.AddIcon;
        public byte[] RemoveIcon => theme.RemoveIcon;
        public byte[] UpdateIcon => theme.UpdateIcon;

        public ICommand ApplyCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ChangeCommand { get; }

        public List<ITableViewModel> Tables { get; }
        public ITableViewModel SelectedTable
        {
            get { return selectedTable; }
            set
            {
                if (selectedTable == value)
                {
                    return;
                }
                selectedTable = value;

                selectedTable.UpdateTable();
                RaisePropertyChanged(nameof(SelectedTable));
            }
        }


        public event Action<ITableEntityViewModel> AddEntity;
    }
}
