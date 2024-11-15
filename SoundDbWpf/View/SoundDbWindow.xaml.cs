using SoundDbWpf.Theme;
using SoundDbWpf.ViewModel;
using System.Windows;

namespace SoundDbWpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SoundDbWindow : Window
    {
        public SoundDbWindow()
        {
            InitializeComponent();

            var theme = new LightTheme();
            var model = new SoundDbModel.SoundDbModel();
            var vm = new SoundDbViewModel(model, theme);
            this.DataContext= vm;

        }

    }
}
