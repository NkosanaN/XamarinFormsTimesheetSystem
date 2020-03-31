using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Text;

namespace App3
{
    public static class Settings
    {
        public static ChiliDataClient GetClient()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
            (se, cert, chain, sslerror) =>
            {
                return true;
            };

            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
            };

            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.TextEncoding = System.Text.Encoding.UTF8;
            var ea = new EndpointAddress("https://172.29.233.9:8736/api/provider.svc");

            ChiliDataClient svc = new ChiliDataClient(binding, ea);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            svc.ClientCredentials.UserName.UserName = "nkosana@datasaint.com";
            svc.ClientCredentials.UserName.Password = "45-@NkO!@";

            return svc;
        }
    }
}