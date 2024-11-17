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
            var vm = new SoundDbViewModel( theme);
            this.DataContext= vm;

        }

    }
}
