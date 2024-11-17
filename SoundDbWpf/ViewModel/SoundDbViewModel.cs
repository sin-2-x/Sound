using CommonWpf.ViewModel;
using SoundDbWpf.Theme;
using SoundDbWpf.ViewModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundDbWpf.ViewModel
{
    internal class SoundDbViewModel : NotifyPropertyChanged
    {
        private readonly ITheme theme;

        private ITableViewModel selectedTable;
        public SoundDbViewModel(ITheme theme)
        {
            this.theme = theme;

            Tables = new List<ITableViewModel>();

            var deviceTableViewModel = new DeviceTableViewModel();
            var workSessionTableViewModel = new WorkSessionTableViewModel();
            var deviceWorkSessionTableViewModel = new DeviceWorkSessionTableViewModel(deviceTableViewModel, workSessionTableViewModel);

            Tables = new List<ITableViewModel> {deviceTableViewModel,
                workSessionTableViewModel,
                deviceWorkSessionTableViewModel
            };

            AddCommand = new ActionCommand(o =>
            {
                RunCommand(SelectedTable.AddImpl);
            });

            RemoveCommand = new ActionCommand(o =>
            {
                RunCommand(SelectedTable.RemoveImpl);
            });

            ApplyCommand = new ActionCommand(o =>
            {
                RunCommand(SelectedTable.SaveImpl);
            });

            UpdateCommand = new ActionCommand(o =>
            {
                RunCommand(SelectedTable.UpdateImpl);
            });

            SelectedTable = Tables.First();
        }

        public byte[] AddIcon => theme.AddIcon;
        public byte[] RemoveIcon => theme.RemoveIcon;
        public byte[] UpdateIcon => theme.UpdateIcon;


        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ApplyCommand { get; }
        public ICommand UpdateCommand { get; }

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

                UpdateCommand.Execute(null);
                RaisePropertyChanged(nameof(SelectedTable));
            }
        }

        private async void RunCommand(Action commandImpl)
        {
            try
            {
                await Task.Run(() => commandImpl());
            }
            catch (Exception)
            {

            }
        }
    }
}
