using CommonWpf.ViewModel;
using SoundDbWpf.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SoundDbWpf.ViewModel
{
    internal class SoundDbViewModel : NotifyPropertyChanged
    {
        private readonly ITheme theme;

        private TablesEnum selectedTable;
        public SoundDbViewModel(ITheme theme)
        {
            this.theme = theme;
        }

        public byte[] AddIcon => theme.AddIcon;
        public byte[] RemoveIcon => theme.RemoveIcon;
        public byte[] UpdateIcon => theme.UpdateIcon;

        public Array Tables { get; } = Enum.GetValues(typeof(TablesEnum));
        public TablesEnum SelectedTable { get { return selectedTable; } set {
                if (selectedTable == value)
                {
                    return;
                }
                selectedTable = value;
                RaisePropertyChanged(nameof(SelectedTable));
            } }
    }
}
