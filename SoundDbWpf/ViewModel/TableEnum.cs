using System.ComponentModel;
using CommonWpf.Converters;

namespace SoundDbWpf.ViewModel
{
    [TypeConverter(typeof(EnumToStringConverter))]
    public enum TableEnum
    {
        [Description("Устройства")]
        Device,
        [Description("Рабочие сессии устройств")]
        DeviceWorkSession,
        [Description("Аудиосигналы")]
        AudioSignal,
        [Description("Сессии анализа")]
        AnalyzeSession,
        [Description("Результаты сессий анализа")]
        AnalyzeSessionResult,
        [Description("Рабочие сессии")]
        WorkSession

    }
}
