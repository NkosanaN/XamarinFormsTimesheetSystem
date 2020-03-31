using App3.Model;
using App3.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTimesheetPage : ContentPage
    {

        public CommonViewModel cm = new CommonViewModel();
        public List<TimeCodes> timecodelist { get; set; }
        public List<Employee> emplist { get; set; }
        public List<Debtor> custList { get; set; }
        public AddTimesheetPage()
        {
            InitializeComponent();
            Populate();
        }
        private void BacktoMain(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MainMenu());
        }

        public async void Populate()
        {
            //emplist = await service.GetEmpList();
            //empList1.ItemsSource = emplist;

            custList = await cm.GetDebtorList();
            debt.ItemsSource = custList;

            timecodelist = await cm.GetTimeCodeList();
            time.ItemsSource = timecodelist;
        }
        public void OnEmp(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                picker.BackgroundColor = Color.FromHex("#ed3c0b");
            }
        }
        public void OnTime(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                picker.BackgroundColor = Color.FromHex("#ed3c0b");
            }
        }
        public void Ondebtor(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                picker.BackgroundColor = Color.FromHex("#ed3c0b");
            }
        }
    }
}
