using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using App3.Controls;
using App3.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Dropdown), typeof(DropdownRenderer))]
namespace App3.Droid
{
    public class DropdownRenderer : ViewRenderer<Dropdown, Spinner>
    {
        Spinner spinner;
        public DropdownRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Dropdown> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                spinner = new Spinner(Context); //(Spinner)FindViewById(Resource.Layout.Spinner);
                SetNativeControl(spinner);
            }

            if (e.OldElement != null)
            {
                Control.ItemSelected -= OnItemSelected;
            }
            if (e.NewElement != null)
            {
                var view = e.NewElement;
                //ArrayAdapter adapter = new ArrayAdapter(Context, Resource.Layout.Spinner, view.ItemsSource.ToList());
                //adapter.SetDropDownViewResource(Resource.Layout.support_simple_spinner_dropdown_item);
                //spinner.setada
                //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleListItem1);
                //var spinner = FindViewById<Spinner>(Resource.Id.action_bar_spinner);
                //Control.Adapter = adapter;

                if (view.SelectedIndex != -1)
                {
                    Control.SetSelection(view.SelectedIndex);
                }

                Control.ItemSelected += OnItemSelected;
                view.CornerRadius = 20;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var view = Element;
            if (e.PropertyName == Dropdown.ItemsSourceProperty.PropertyName)
            {
                //ArrayAdapter adapter = new ArrayAdapter(Context, Resource.Layout.Spinner, view.ItemsSource.ToList());
                //adapter.SetDropDownViewResource(Resource.Layout.support_simple_spinner_dropdown_item);
                //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleListItem1);
                //var spinner = (Spinner)FindViewById<Spinner>(Resource.Id.action_bar_spinner);
                //Control.Adapter = adapter;
            }
            if (e.PropertyName == Dropdown.SelectedIndexProperty.PropertyName)
            {
                Control.SetSelection(view.SelectedIndex);
            }
            base.OnElementPropertyChanged(sender, e);
        }

        private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var view = Element;
            if (view != null)
            {
                view.SelectedIndex = e.Position;
                view.OnItemSelected(e.Position);
            }
        }
    }
}