using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Model
{
    public class Employee
    {
        public string CoyCode { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string PostCode { get; set; }
        public string PostName { get; set; }
        public string StatusCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LanguageCode { get; set; }
        public DateTime LastSyncDate { get; set; }
        public string CostCentreCode { get; set; }
        public string EmployeeIndNo { get; set; }
        public string EmployeeGender { get; set; }
        public string DebtorCode { get; set; }
        public bool HasTran { get; set; }

        public Employee(int EmployeeCode ,string EmployeeName, DateTime StartDate) 
        {
            this.EmployeeCode = EmployeeCode;
            this.EmployeeName = EmployeeName;
            this.StartDate = StartDate;
        }
        public Employee() { }

    }
}
