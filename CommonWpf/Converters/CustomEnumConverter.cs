using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonWpf.Converters
{
    public class CustomEnumConverter : EnumConverter
    {
        public CustomEnumConverter(Type type)
            : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string) || value == null)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            string text = value.ToString();
            FieldInfo[] fields = value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name == text)
                {
                    DescriptionAttribute[] array = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), inherit: true);
                    if (array.Any())
                    {
                        return array[0];
                    }
                }
            }

            return text;
        }
    }
}
