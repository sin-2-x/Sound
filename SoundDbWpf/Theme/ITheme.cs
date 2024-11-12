using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbWpf.Theme
{
    internal interface ITheme
    {
        byte[] UpdateIcon { get; }
        byte[] AddIcon { get; }
        byte[] RemoveIcon { get; }
    }
}
