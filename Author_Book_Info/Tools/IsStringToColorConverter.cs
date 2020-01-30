using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Author_Book_Info.Tools
{
    public class IsStringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var language = value;

            if (value==null)
            {
                return new SolidColorBrush(Colors.White);
            }

            switch (language.ToString())
            {
                case "EN":
                    return new SolidColorBrush(Colors.AliceBlue);
                case "RU":
                    return new SolidColorBrush(Colors.BlueViolet);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}