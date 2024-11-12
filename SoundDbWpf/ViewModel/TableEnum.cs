using EnumStringValues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommonWpf.Converters;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
