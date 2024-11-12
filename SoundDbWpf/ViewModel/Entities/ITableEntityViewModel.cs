using CommonWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundDbWpf.ViewModel.Entities
{
    public interface ITableEntityViewModel 
    {
         ICommand ApplyCommand { get;  }
    }
}
