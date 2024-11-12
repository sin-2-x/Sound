using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonWpf.Converters
{
    public class BytesToImageSourceConverter : Singleton<BytesToImageSourceConverter>, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[]))
            {
                return DependencyProperty.UnsetValue;
            }

            try
            {
                return Convert((byte[])value);
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }

        }

        public static DrawingImage Convert(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);

            var wpfSettings = new WpfDrawingSettings();
            wpfSettings.CultureInfo = wpfSettings.NeutralCultureInfo;

            var reader = new FileSvgReader(wpfSettings);

            var drawing = reader.Read(stream);

            return new DrawingImage(drawing);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
