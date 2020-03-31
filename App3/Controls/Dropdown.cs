using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace App3.Controls
{
    public class Dropdown : View
    {
        public static readonly BindableProperty CornerRaduisProperty = BindableProperty.Create(
            nameof(CornerRadius), 
            typeof(double), 
            typeof(Dropdown), 
            default(double));

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRaduisProperty); }
            set { SetValue(CornerRaduisProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(Dictionary<string, string>),
            declaringType: typeof(Dictionary<string, string>),
            defaultValue: null);

        public Dictionary<string, string> ItemsSource
        {
            get { return (Dictionary<string, string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
            propertyName: nameof(SelectedIndex),
            returnType: typeof(int),
            declaringType: typeof(int),
            defaultValue: -1);

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

        public void OnItemSelected(int pos)
        {
            ItemSelected?.Invoke(this, new ItemSelectedEventArgs() { SelectedIndex = pos });
        }
    }

    public class ItemSelectedEventArgs : EventArgs
    {
        public int SelectedIndex { get; set; }
    }

}
