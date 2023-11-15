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

                switch (dangerLevel)
                {
                    case 3:
                        return Colors.Red; // Assuming you are using MAUI, use Colors
                    case 2:
                        return Colors.Yellow;
                    default:
                        return Colors.Green;
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
