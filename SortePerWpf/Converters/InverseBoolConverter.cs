using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SortePerWpf.Converters
{
    /// <summary>
    /// Will inverse a booleans value 
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            if (value is bool)
                val = !(bool)value;

            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            if (value is bool)
                val = !(bool)value;

            return val;
        }
    }
}
