using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Validation
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);

        bool HrCheck(T value);
    }
}
