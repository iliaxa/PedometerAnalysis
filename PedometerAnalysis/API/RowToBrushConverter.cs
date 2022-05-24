using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PedometerAnalysis.API;
public class RowToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(Brush))
        {
            return null;
        }

        var r = value as UserInfo;
        var differece = r.Average * 0.2;
        if (r == null || (r.Min + differece) < r.Average || (r.Max - differece) > r.Average)
        {
            return Brushes.GreenYellow;
        }

        return Brushes.White;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Brushes.White;
    }
}
