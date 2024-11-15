using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace CommonWpf.Converters
{
    public class EnumToStringConverter : EnumConverter
    {
        public EnumToStringConverter(Type type) : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var enumType = value.GetType();
            var memberInfos = enumType.GetMember(value.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return valueAttributes.Any() ? ((DescriptionAttribute)valueAttributes[0]).Description : value.ToString();
        }
    }
}
