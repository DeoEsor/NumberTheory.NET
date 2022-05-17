using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CryptoDesktop.MVVM.Convertors;

public class ByteStringConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is byte[] message))
            throw new ArgumentException("Parameter incorrect", nameof(parameter));

        return Encoding.UTF8.GetString(message);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is string message))
            throw new ArgumentException("Parameter incorrect", nameof(parameter));

        return Encoding.UTF8.GetBytes(message);
    }
}