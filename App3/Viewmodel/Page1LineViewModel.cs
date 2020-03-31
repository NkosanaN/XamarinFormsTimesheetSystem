using App3.Validation;
using ChiliSuite.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.Viewmodel
{
    public class Page1LineViewModel : ViewModelBase
    {
        bool results = false, x = false;
        private bool _isValid;
        private static ChiliDataClient client;
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;
        private ValidatableObject<string> _taskdescription;
        List<JobTasks> final = new List<JobTasks>();
        public string s;
        public ChiliSuite.Api.Jobs Jbmodel { get; }



        public Page1LineViewModel()
        {
            PaymentLines = new ObservableCollection<JobTasks>();
            PaymentLines.Add(new JobTasks() { TaskNo = 1, TargetDate = DateTime.Now, Chargable = true });

            AddCommand = new Command<JobTasks>((paymentLigne) =>
            {
                PaymentLines.Add(new JobTasks
                {
                    TaskNo = PaymentLines.Count + 1,
                    Chargable = true,
                    CoyCode = "T",
                    TargetDate = DateTime.Now,
                    //TaskDescription = s
                });
            });


            DeleteCommand = new Command<JobTasks>((paymentLigne) =>
            {
                PaymentLines.Remove(paymentLigne);
            });
        }


        private JobTasks _selectedItem { get; set; }
        public JobTasks SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }

        public ICommand DeleteCommand { protected set; get; }

        public ICommand AddCommand { protected set; get; }
        ObservableCollection<JobTasks> _paymentLines;
        public ObservableCollection<JobTasks> PaymentLines
        {
            get { return _paymentLines; }
            set
            {
                if (_paymentLines != value)
                {
                    _paymentLines = value;
                    OnPropertyChanged("PaymentLines");
                }
            }
        }

        public Page1LineViewModel(ChiliSuite.Api.Jobs job)
        {
            client = Settings.GetClient();
            _taskdescription = new ValidatableObject<string>();
            this._navigationService = DependencyService.Get<Services.INavigationService>();
            this._messageService = DependencyService.Get<Services.IMessageService>();
            Jbmodel = job;
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

        #region jobtask property
        public ValidatableObject<string> TaskDescription
        {
            get
            {
                return _taskdescription;
            }
            set
            {
                _taskdescription = value;
                RaisePropertyChanged(() => TaskDescription);
            }
        }
        #endregion

        //public ICommand AddLineCommand => new Command(async () => await AddJobCardAndLine());

    }
}