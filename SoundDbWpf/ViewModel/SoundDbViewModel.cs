using CommonWpf.ViewModel;
using SoundDbWpf.Theme;
using SoundDbWpf.ViewModel.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SoundDbWpf.ViewModel
{
    internal class SoundDbViewModel : NotifyPropertyChanged
    {
        private readonly ITheme theme;

        private ITableViewModel selectedTable;
        public SoundDbViewModel( ITheme theme)
        {
            this.theme = theme;

            Tables = new List<ITableViewModel> {
                new DeviceTableViewModel(),
                new DeviceWorkSessionTableViewModel(new DeviceTableViewModel(), new WorkSessionTableViewModel()),
                /*new AnalyzeSessionResultTableViewModel(model),
                new AnalyzeSessionTableViewModel(model),
                new AudioSignalTableViewModel(model),
                */
                new WorkSessionTableViewModel()
            };

            AddCommand = new ActionCommand(o =>
            {
                SelectedTable.AddImpl();
            });

            RemoveCommand = new ActionCommand(o =>
            {
                SelectedTable.RemoveImpl();
            });

            ApplyCommand = new ActionCommand(o =>
            {
                SelectedTable.SaveImpl();
            });

            UpdateCommand = new ActionCommand(o =>
            {
                SelectedTable.UpdateImpl();

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

    }
}
