using App3.Model;
using App3.Views.Mock;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App3.Viewmodel
{
    public class MockListViewEmployee:ViewModelBase
    {
        public ObservableCollection<Employee> employees { get; set; }

        public MockListViewEmployee() 
        {
            employees = new ObservableCollection<Employee>();

            //employees.Add(new Employee(1, "nkosana", DateTime.Now));
            //employees.Add(new Employee(1, "loyd", DateTime.Now.AddDays(-2)));
            //employees.Add(new Employee(1, "glory", DateTime.Now.AddDays(-4)));


            //MessagingCenter.Subscribe<AddOrEditPage,Employee>(this, "AddEmp",
            //    (page, emp) =>
            //    {
            //        employees.Add(emp);
            //    });

            MessagingCenter.Subscribe<AddOrEditPage, Employee >(this, "AddEmp",
                (page, emp) =>
                {
                    employees.Add(emp);
                });


            //MessagingCenter.
        }

    }
}
