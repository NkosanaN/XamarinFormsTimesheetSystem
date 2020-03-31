using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App3.Helpers
{
    public class RoundMyNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //double result = 0;
            //if (value != null && (double.TryParse(value.ToString(), out result)))
            //    return Math.Round(result, 1);
            //else
            //    return value;

            if (value == null)
                return "";
            return value.ToString().Replace(".", ",");
        }

        public object ConvertBack(object value, Type targetType, object paramater, CultureInfo culture)
        {
            return value;
        }
    }
}
