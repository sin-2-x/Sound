using SoundDbWpf.ViewModel.Tables;
using System.Windows;
using System.Windows.Controls;

namespace SoundDbWpf.View.Tables
{
    internal class SelectedTableTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item != null&& item is ITableViewModel vm)
            {

                return element.TryFindResource(vm.TableEnum) as DataTemplate;

            }
            return null;
        }
    }
}
