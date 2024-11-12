using SoundDbWpf.Theme;
using SoundDbWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            var vm = new SoundDbViewModel(theme);
            this.DataContext= vm;
        }
    }
}
