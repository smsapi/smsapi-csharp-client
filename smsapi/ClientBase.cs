using System;
using System.Diagnostics;
using System.Reflection;

namespace SMSApi.Api
{
    public abstract class ClientBase
    {
        private readonly string _clientAgent;

        public ClientBase()
        {
            _clientAgent = $"smsapi-csharp-client:{Assembly.GetExecutingAssembly().GetName().Version};{Environment.Version}";
        }

        public abstract string GetAuthenticationHeader();

        public string GetClientAgentHeader()
        {
            return _clientAgent;
        }
    }
}
