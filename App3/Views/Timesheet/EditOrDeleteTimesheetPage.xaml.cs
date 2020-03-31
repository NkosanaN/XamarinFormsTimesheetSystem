using App3.Model;
using App3.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrDeleteTimesheetPage : ContentPage
    {
        public CommonViewModel cm = new CommonViewModel();
        public List<TimeCodes> timecodelist { get; set; }
        public List<Debtor> debtorList { get; set; }

        public EditOrDeleteTimesheetPage(Timesheet model)
        {
            InitializeComponent();
            Populate();
            var edittimesheetViewModel = new EditTimeViewModel();
            edittimesheetViewModel.timesheetmodel = model;
            BindingContext = edittimesheetViewModel;
        }
        public async void Populate()
        {
            debtorList = await cm.GetDebtorList();
            debt.ItemsSource = debtorList;

            timecodelist = await cm.GetTimeCodeList();
            time.ItemsSource = timecodelist;
        }
        private void BacktoMain(object sender, EventArgs e)
        {

        }
    }
}