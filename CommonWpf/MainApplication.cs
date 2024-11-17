using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CommonWpf
{
    public static class MainApplication
    {
        public static void InvokeInGuiThread(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }

        public static void BeginInvokeInGuiThread(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(action);
        }

        public static bool InvokeRequired => !Application.Current.Dispatcher.CheckAccess();
    }
}
