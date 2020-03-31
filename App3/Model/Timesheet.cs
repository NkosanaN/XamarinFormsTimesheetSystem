using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class Timesheet
    {
        public string CoyCode { get; set; }
        public int EmployeeCode { get; set; }
        public long TimesheetID { get; set; }
        public DateTime TimesheetDate { get; set; }
        public string DebtorCode { get; set; }
        public string TimesheetRef { get; set; }
        public decimal TimesheetHours { get; set; }
        public bool TimesheetChargeable { get; set; }
        public string TimesheetComment { get; set; }
        public int TimesheetYear { get; set; }
        public int TimesheetMonth { get; set; }
        public string TimeCode { get; set; }
        public bool Invoiced { get; set; }
        public string EmployeeName { get; set; }
        public string TimeCodeDescription { get; set; }
        public string DebtorName { get; set; }
        public bool HasTran { get; set; }


    }

}
