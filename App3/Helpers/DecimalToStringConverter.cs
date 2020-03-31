using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App3.Helpers
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value == null)
            //    return "";
            //decimal i = (decimal)value;
            ////return i.ToString();
            //return $"{i.ToString().Replace("0","")}";


            if (value.ToString().Contains("0"))
                value = "";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string strValue = value as string;
            //if (string.IsNullOrEmpty(strValue))
            //    strValue = "0";

            decimal resultdecimal;

            if (decimal.TryParse(value as string, out resultdecimal))
            {
                return resultdecimal;
            }
            return resultdecimal;

            //return value;
        }
    }
}
