using SoundDbWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SoundDbWpf.View.Tables
{
    internal class SelectedTableTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item != null)
            {
                if (item is TablesEnum.Table1)
                {
                    return element.FindResource("Table1") as DataTemplate;
                }
                if (item is TablesEnum.Table2)
                {
                    return element.FindResource("Table2") as DataTemplate;
                }
                
            }
            return null;
        }
    }
}
