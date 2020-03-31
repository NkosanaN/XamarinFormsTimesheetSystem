using App3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.Viewmodel
{
    public class EditTimeViewModel : ViewModelBase
    {
        bool isBusy;
        public TimeCodes model { get; set; }
        private static ChiliDataClient client;
        public Timesheet timesheetmodel { get; set; }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        Debtor selectedDebt;
        TimeCodes selectedTime;

        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;

        public EditTimeViewModel()
        {
            client = Settings.GetClient();
            this._messageService = DependencyService.Get<Services.IMessageService>();
            this._navigationService = DependencyService.Get<Services.INavigationService>();
        }

        public ICommand EditTimesheetCommand => new Command(async () => await EditTimesheet());
        public ICommand DeleteTimesheetCommand => new Command(async () => await DeleteTimesheet());
        public Debtor SelectedDebt
        {
            get { return selectedDebt; }
            set
            {
                if (SelectedDebt != value || SelectedDebt != null)
                {
                    selectedDebt = value;
                    OnPropertyChanged();
                }
            }
        }
        public TimeCodes SelectedTimeCode
        {
            get { return selectedTime; }
            set
            {
                if (SelectedTimeCode != value || SelectedTimeCode != null)
                {
                    selectedTime = value;
                    OnPropertyChanged();
                }
            }
        }

        #region TimeCodes
        public ICommand EditTimeCodes
        {
            get
            {
                return new Command(async () =>
                {
                   // await _apiService.PutTimeCodes(model/*string accessToken*/);
                });
            }
        }
        public ICommand DeleteTimeCodes
        {
            get
            {
                return new Command(async () =>
                {
                   // await _apiService.DeleteTimeCodes(model.TimeCode/*,Settings.AccessToken*/);
                });
            }
        }
        #endregion

        #region Timesheet

        public async Task EditTimesheet()
        {
            if (SelectedDebt != null)
            {
                timesheetmodel.DebtorCode = SelectedDebt.DebtorCode;
            }
            else
            {
                timesheetmodel.DebtorCode = timesheetmodel.DebtorCode;
            }
            if (SelectedTimeCode != null)
            {
                timesheetmodel.TimeCode = SelectedTimeCode.TimeCode;
            }
            else
            {
                timesheetmodel.TimeCode = timesheetmodel.TimeCode;
            }

            var timesheet = new ChiliSuite.Api.Timesheet
            {
                CoyCode = "T",
                EmployeeCode = 3,
                TimesheetID = timesheetmodel.TimesheetID,
                TimesheetDate = DateTime.Now,
                TimeCode = timesheetmodel.TimeCode,
                DebtorCode = timesheetmodel.DebtorCode,
                TimesheetRef = timesheetmodel.TimesheetRef ,
                TimesheetComment = timesheetmodel.TimesheetComment,
                TimesheetChargeable = true,
                TimesheetHours = timesheetmodel.TimesheetHours,
                Invoiced = false,
                TimesheetYear = DateTime.Now.Year,
                TimesheetMonth = DateTime.Now.Month,
            };

            bool x = client.PostTimesheet("T", "nkosana@datasaint.com", timesheet, ChiliSuite.Api.ProcessOption.Edit);

            if (x)
            {
                await Task.Delay(1000);
                this._messageService.Alert("Successfuly", $"{timesheetmodel.EmployeeName} record has been successfuly edited");
                IsBusy = true;
                await this._navigationService.NavigateToTimesheet();
            }
            else
            {
                IsBusy = true;
                this._messageService.Alert("Fail", "Oops can't edit a record");
            }
        }
        public async Task DeleteTimesheet()
        {
            bool answer = await this._messageService.ShowAsync("Delete", "Are you sure you want to delete");

            if (answer)
            {
                await Task.Delay(1000);

                var timesheet = new ChiliSuite.Api.Timesheet
                {
                    CoyCode = "T",
                    TimesheetID = timesheetmodel.TimesheetID
                };

                bool x = client.PostTimesheet("T", "nkosana@datasaint.com", timesheet, ChiliSuite.Api.ProcessOption.Delete);

                if (x)
                    await this._navigationService.NavigateToTimesheet();
                else
                    this._messageService.Alert("Error", $"Oops failed to delete a record for {timesheetmodel.EmployeeName}");
            }
            else
            {
                await this._navigationService.NavigateToTimesheet();
            }

        }
        #endregion
    }
}
