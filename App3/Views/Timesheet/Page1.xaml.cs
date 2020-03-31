using App3.Viewmodel;
using ChiliSuite.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lottie : ContentPage
    {
        private List<JobTasks> PaymentLines = new List<JobTasks>();
        public Lottie()
        {
            InitializeComponent();

            

            BindingContext = new Page1LineViewModel();
        }
    }
}