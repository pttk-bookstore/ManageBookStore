using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookStore.VIEW.Converter
{
    class StatusIntToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                if ((int)value == 1)
                {
                    return "Đã thanh toán";
                }
                else if((int)value == 2)
                {
                    return "Chưa thanh toán";
                }
                else if ((int)value == 3)
                {
                    return "Đang giao";
                }
            }

            return "Đã thanh toán";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
