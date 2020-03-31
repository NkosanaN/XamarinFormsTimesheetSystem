using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }
    }
}
