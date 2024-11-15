using System.Windows;
using System.Windows.Controls;

namespace SoundDbWpf.View.Tables
{
    /// <summary>
    /// Interaction logic for DevicesTable.xaml
    /// </summary>
    public partial class DevicesTable : UserControl
    {
        public DevicesTable()
        {
            InitializeComponent();
            this.DataContextChanged += DevicesTable_DataContextChanged;
        }

        private void DevicesTable_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
