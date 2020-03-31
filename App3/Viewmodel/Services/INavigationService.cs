using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Viewmodel.Services
{
    public interface INavigationService
    {
        Task NavigateToTimesheet();

        Task NavigateToUsers();

        Task NavigateToLogin();
    }
}