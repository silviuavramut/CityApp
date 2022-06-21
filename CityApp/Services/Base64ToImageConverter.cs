using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Services
{
    public class Base64ToImageConverter : IValueConverter
    {
        ImageSource image;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            image = null;
            byte[] bytes = System.Convert.FromBase64String(value.ToString());
            image = ImageSource.FromStream(() => new MemoryStream(bytes));
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
