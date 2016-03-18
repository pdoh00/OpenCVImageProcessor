using System;
using System.Windows.Data;

namespace ImageProcessingApp.Converters
{
    public class CanvasImageCenteringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //AssertThat.ArgumentNotNull(values, "values must not be null");

            double canvasLength = (double)values[0];
            double imageLength = (double)values[1];

            return (canvasLength / 2) - (imageLength / 2);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
