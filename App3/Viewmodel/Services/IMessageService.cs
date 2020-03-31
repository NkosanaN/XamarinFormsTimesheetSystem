using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Viewmodel.Services
{
    public interface IMessageService
    {
        Task<bool> ShowAsync(string header, string message);

        void Alert(string errMessage, string message);
    }
}
