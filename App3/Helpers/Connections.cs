using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace App3
{
    public class Connections
    {
        private EndpointAddress endpnt;
        private bool _created = false;
        private ChiliDataClient _client;
        private string _url;

        public bool Created { get { return _created; } }

        public string URL { get { return _url; } set { _url = value; } }

        public Connections(string url)
        {
            if (!string.IsNullOrEmpty(url))
                _url = url;

            if (!string.IsNullOrEmpty(_url))
            {
                if (_client == null)
                    InitializeServiceClient();
            }
        }

        public ChiliDataClient Client()
        {
            if (_client == null)
                InitializeServiceClient();
            return _client;
        }

        private void InitializeServiceClient()
        {
            if (!string.IsNullOrEmpty(_url))
            {
                if (_url != null && !string.IsNullOrEmpty(_url))
                {
                    try
                    {
                        endpnt = new EndpointAddress(_url);
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    return; // throw new NotImplementedException("Endpoint address not defined");
                }

                BasicHttpBinding binding = CreateBasicHttp();

                _client = new ChiliDataClient(binding, endpnt);

                _created = true;
            }
        }

        private BasicHttpBinding CreateBasicHttp()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
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
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            return binding;
        }
    }
}