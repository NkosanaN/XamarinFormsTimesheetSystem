using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.Mock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpListViewPage : ContentPage
    {
        public EmpListViewPage()
        {
            InitializeComponent();
        }

        private async void NavTo(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new AddOrEditPage());
        }
    }
}