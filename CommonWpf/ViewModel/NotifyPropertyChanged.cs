using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonWpf.ViewModel
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate
        {
        };

        public void SetProperty<T>(ref T x, T value, string name)
        {
            if ((x == null || !x.Equals(value)) && (x != null || value != null))
            {
                x = value;
                RaisePropertyChanged(name);
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
