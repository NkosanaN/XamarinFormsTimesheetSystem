using App3.Model;
using App3.Viewmodel;
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
    public partial class AddOrEditPage : ContentPage
    {
        public AddOrEditPage()
        {
            InitializeComponent();
        }

        private void NavBack(object sender, EventArgs e)
        {
            Employee employee = ((MockAddOrEditViewModel)BindingContext).Employee;

            MessagingCenter.Send(this, "AddEmp", employee);

            Navigation.PopModalAsync();
        }
    }
}