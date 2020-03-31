using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetView : ContentPage
    {
    
        public TimesheetView()
        {
            InitializeComponent();

            BindingContext = new TimesheetViewModal(); 

        }

        private void NavigateToAddNewTimesheet_Clicked(object sender, EventArgs e)
        {

        }
        private double _oldwidth, _oldheight;

        private async void TimeCodesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var model = e.Item as Timesheet;
            await Navigation.PushModalAsync(new NavigationPage(new EditOrDeleteTimesheetPage(model)));
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != _oldwidth || height != _oldheight)
            {
                _oldwidth = width;
                _oldheight = height;

                if (width > height)
                {
                    //outerLayer.Orientation = StackOrientation.Horizontal;
                    firstLayer.IsVisible = false;
                    outerLayer.IsVisible = true;
                }
                else
                {
                    //outerLayer.Orientation = StackOrientation.Horizontal;
                    firstLayer.IsVisible = true;
                    outerLayer.IsVisible = false;
                }
            }
        }
    }

}