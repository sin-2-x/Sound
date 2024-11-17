using SoundDbWpf.Properties;

namespace SoundDbWpf.Theme
{
    internal class LightTheme : ITheme
    {
        public byte[] UpdateIcon => Resources.UpdateIcon;
        public byte[] ApplyIcon => Resources.ApplyIcon;

        public byte[] AddIcon => Resources.AddIcon;

        public byte[] RemoveIcon => Resources.RemoveIcon;
    }
}
