namespace SoundDbWpf.Theme
{
    internal interface ITheme
    {
        byte[] UpdateIcon { get; }
        byte[] AddIcon { get; }
        byte[] RemoveIcon { get; }
        byte[] ApplyIcon { get; }
    }
}
