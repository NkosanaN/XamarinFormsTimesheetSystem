using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public class TimesheetViewModal : ViewModelBase
    {
        private static ChiliDataClient client;
        bool isBusy;
        public ObservableCollection<List<Timesheet>> list { get; set; }
        public ObservableCollection<Timesheet> timesheet { get; set; }
        public Command LoadItemCommand { get; set; }
        public TimesheetViewModal()
        {
            client = Settings.GetClient();
            timesheet = new ObservableCollection<Timesheet>();
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public async void ExecuteLoadItemsCommand()
        {
            var items = client.GetTimesheets("T", "nkosana@datasaint.com", 3);
            client.BeginGetTimesheets("T", "nkosana@datasaint.com", 3, timesheetcallback, TaskCreationOptions.None);
        }
        private async void timesheetcallback(IAsyncResult result) 
        {
            var b = client.EndGetTimesheets(result);

            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    timesheet.Add(new Timesheet
                    {
                        CoyCode = "T",
                        TimesheetDate = b.FirstOrDefault().TimesheetDate
                                                  ,
                        DebtorName = b.FirstOrDefault().DebtorCode
                                                  ,
                        TimesheetRef = b.FirstOrDefault().TimesheetRef
                                                  ,
                        TimesheetHours = b.FirstOrDefault().TimesheetHours
                    });
                }
                catch (NullReferenceException)
                {
                    return;
                }
            });
        }
    }
}