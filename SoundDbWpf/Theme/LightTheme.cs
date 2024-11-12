using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundDbWpf.Properties;

namespace SoundDbWpf.Theme
{
    internal class LightTheme : ITheme
    {
        public byte[] UpdateIcon => Resources.ChangeIcon;

        public byte[] AddIcon => Resources.AddIcon;

        public byte[] RemoveIcon => Resources.RemoveIcon;
    }
}
