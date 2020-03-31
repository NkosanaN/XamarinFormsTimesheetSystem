using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Validation
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        decimal dec, min = 0.1m, max = 9m;
        bool flag = false;
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
        public bool HrCheck(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            dec = Convert.ToDecimal(str);

            return !(string.IsNullOrWhiteSpace(str) && (Convert.ToDecimal(str) > min) && (Convert.ToDecimal(str) < max));

        }
    }
}
