using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.Controls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty CornerRaduisProperty =
           BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(CustomPicker), default(double));


        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomPicker), string.Empty);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRaduisProperty); }
            set { SetValue(CornerRaduisProperty, value); }
        }
    }
}
