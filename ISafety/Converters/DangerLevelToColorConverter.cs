using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ISafety.Converters
{
    public class DangerLevelToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var dangerLevel = (int)value;
                var lightRed = Color.FromRgb(248, 124, 86);
                var lightOrange = Color.FromRgb(248, 205, 86);
                var lightGreen = Color.FromRgb(169, 248, 86);

                switch (dangerLevel)
                {
                    case 3:
                        return lightRed; // Assuming you are using MAUI, use Colors
                    case 2:
                        return lightOrange;
                    default:
                        return lightGreen;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or use the debugger to inspect 'ex'
                return Colors.Gray; // Return a default color in case of an error
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
