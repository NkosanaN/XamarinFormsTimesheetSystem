using App3.Model;
using App3.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.Viewmodel
{
    public class AddTimeViewModel : ViewModelBase
    {
        private static ChiliDataClient client;
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;
        private bool _isValid;
        private ValidatableObject<int> _employeecode;
        private ValidatableObject<DateTime> _timesheetdate;
        private ValidatableObject<string> _debtorcode;
        private ValidatableObject<string> _timesheetref;
        private string _timesheethours;
        //private ValidatableObject<string> _timesheethours;
        private ValidatableObject<string> _timesheetcomment;
        private ValidatableObject<bool> _timesheetchargeable;
        private ValidatableObject<string> _timecode;
        bool isBusy;
        public AddTimeViewModel()
        {
            client = Settings.GetClient();
            _timecode = new ValidatableObject<string>();
            _employeecode = new ValidatableObject<int>();
            _timesheetdate = new ValidatableObject<DateTime>();
            _debtorcode = new ValidatableObject<string>();
            _timesheetref = new ValidatableObject<string>();
            //_timesheethours = new ValidatableObject<string>();
            _timesheetcomment = new ValidatableObject<string>();
            _timesheetchargeable = new ValidatableObject<bool>();
            this._navigationService = DependencyService.Get<Services.INavigationService>();
            this._messageService = DependencyService.Get<Services.IMessageService>();
            AddValidation();
        }

        public ICommand AddTimesheetCommand => new Command(async () => await AddTimesheet());

        Employee selectedEmp;
        Debtor selectedDebt;
        TimeCodes selectedTime;

        public bool IsVisible
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        #region Pickers
        public Employee SelectedEmp
        {
            get
            {
                return selectedEmp;
            }
            set
            {
                if (SelectedEmp != value)
                {
                    selectedEmp = value;
                    OnPropertyChanged();
                }
            }
        }
        public Debtor SelectedDebt
        {
            set
            {
                if (selectedDebt != value)
                {
                    selectedDebt = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return selectedDebt;
            }
        }
        public TimeCodes SelectedTimeCode
        {
            get { return selectedTime; }
            set
            {
                if (SelectedTimeCode != value)
                {
                    selectedTime = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region timecodevariables

        public string CoyCode { get; set; }
        public string TimeCode { get; set; }
        public string TimeCodeDescription { get; set; }
        public decimal TimeCodeChargeRate { get; set; }
        public bool DefaultVAT { get; set; }

        #endregion

        #region timesheetproperty


        public ValidatableObject<DateTime> TimesheetDate
        {
            get
            {
                return _timesheetdate;
            }
            set
            {
                _timesheetdate = value;
                RaisePropertyChanged(() => TimesheetDate);
            }
        }
        public ValidatableObject<string> TimesheetRef
        {
            get
            {
                return _timesheetref;
            }
            set
            {
                _timesheetref = value;
                RaisePropertyChanged(() => TimesheetRef);
            }
        }
        public string TimesheetHours
        {
            get
            {
                if (_timesheethours == null)
                    return "";
                else
                    return _timesheethours;
            }
            set
            {
                _timesheethours = value;
                RaisePropertyChanged(() => TimesheetRef);
            }
        }
        public ValidatableObject<string> TimesheetComment
        {
            get
            {
                return _timesheetcomment;
            }
            set
            {
                _timesheetcomment = value;
                RaisePropertyChanged(() => TimesheetComment);
            }
        }
        public ValidatableObject<bool> TimesheetChargeable
        {
            get
            {
                return _timesheetchargeable;
            }
            set
            {
                _timesheetchargeable = value;
                RaisePropertyChanged(() => TimesheetChargeable);
            }
        }
        #endregion
        public ICommand AddTimeCodes
        {
            get
            {
                return new Command(async () =>
                {
                    var timecodes = new TimeCodes
                    {
                        CoyCode = "T",//CoyCode = CoyCode,
                        TimeCode = Convert.ToString(TimeCode),
                        TimeCodeDescription = TimeCodeDescription,
                        TimeCodeChargeRate = TimeCodeChargeRate,
                        DefaultVAT = DefaultVAT
                    };
                   // await timeApi.PostTimeCodes(timecodes/*,string AcessToken*/);
                });
            }
        }
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }
        private async Task AddTimesheet()
        {
            IsBusy = true;
            bool isValid = Validate();
            bool isAuthenticated = false;

            if (isAuthenticated)
            {
                decimal minHr = 0, maxHr = 13m;
                decimal timesheetHr1, timesheetHr2;

                //if (SelectedEmp == null)
                //{
                //    this._messageService.Alert("Fail", "Oops can't create new record. Please select Employee Name from dropdown list");
                //    return;
                //}
                if (SelectedTimeCode == null)
                {
                    this._messageService.Alert("Fail", "Oops can't create new record. Please select TimeCodes from dropdown list");
                    return;
                }

                if (Decimal.TryParse(TimesheetHours .Replace(".", ","), out timesheetHr1))
                    timesheetHr2 = timesheetHr1;
                else
                {
                    this._messageService.Alert("Fail", "Oops can't create new record. Conversion failed when trying to convert Hour(s) dot to comma or the field is empty");
                    return;
                }

                if (!(timesheetHr1 > Convert.ToDecimal(minHr)))
                {
                    this._messageService.Alert("Fail", "Oops can't create new record. Hour(s) rate(s) can't be zero");
                    return;
                }
                if (timesheetHr1 > Convert.ToDecimal(maxHr))
                {
                    this._messageService.Alert("Fail", "Oops can't create new record. Hour(s) rate(s) star from 0.1 to 12");
                    return;
                }
                if (SelectedDebt == null)
                {
                    this._messageService.Alert("Fail", "Oops can't create new record. Debtorcode is required");
                    return;
                }

                var timesheet = new ChiliSuite.Api.Timesheet
                {
                    CoyCode = "T",
                    EmployeeCode = 3,
                    TimeCode = SelectedTimeCode.TimeCode,
                    DebtorCode = SelectedDebt.DebtorCode ?? "",
                    TimesheetRef = Convert.ToString(TimesheetRef.Value),
                    TimesheetComment = Convert.ToString(TimesheetComment.Value),
                    TimesheetChargeable = Convert.ToBoolean(TimesheetChargeable.Value),
                    TimesheetHours = timesheetHr2,
                    Invoiced = false,
                    TimesheetDate  = DateTime.Now,
                    TimesheetYear  = DateTime.Now.Year,
                    TimesheetMonth = DateTime.Now.Month,
                };
                bool x = client.PostTimesheet("T", "nkosana@datasaint.com", timesheet, ChiliSuite.Api.ProcessOption.Add);
                if (x)
                {
                    var p = $"Successful created record";
                    //await this._navigationService.NavigateToTimesheet();
                }
                else
                {
                    //Color color = Color.Red;
                    string message = string.Format("Oops can't create new record. Please check Hour(s) rating entered Hour(s) {0}", TimesheetHours);
                    this._messageService.Alert("Fail", $" {message}");
                }
            }
        }
        private bool Validate()
        {
            bool isValidRef = ValidateRef();

            bool isComment = ValidateComment();

            return isValidRef && isComment;
        }

        private bool ValidateRef()
        {
            return _timesheetref.Validate();
        }

        private bool ValidateComment()
        {
            return _timesheetcomment.Validate();
        }
        private void AddValidation()
        {
            _timesheetref.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Reference is required" });
            _timesheetcomment.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Comment is required" });
        }
    }
}