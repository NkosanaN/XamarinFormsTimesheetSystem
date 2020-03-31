using App3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.Viewmodel
{
    public class MockAddOrEditViewModel
    {
        INavigation Navigation;
        public Employee Employee { get; set; }
        //private int _EmployeeCode;
        //private string _EmployeeName;
        //public ICommand AddCommand => new Command(async () => await AddTimesheet());


        //public int EmployeeCode
        //{
        //    get { return _EmployeeCode; }
        //    set { _EmployeeCode = value; }
        //}
        //public string EmployeeName 
        //{
        //    get { return _EmployeeName; }
        //    set { _EmployeeName = value; }
        //}

        public MockAddOrEditViewModel() 
        {
            Employee = new Employee();
        }

        //private async Task AddTimesheet() 
        //{
        //    var employee = new Employee
        //    {
        //        EmployeeCode = EmployeeCode,
        //        EmployeeName = EmployeeName,
        //        StartDate = DateTime.Now
        //    };

        //    MessagingCenter.Send(this, "AddEmp", employee);
        //    await Navigation.PopModalAsync(true);

        //}
    }
}
