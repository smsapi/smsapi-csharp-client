using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;

namespace SMSApi.Api
{
    public abstract class ClientBase : IClient
    {
        private readonly string _clientAgent;

        protected ClientBase()
        {
            _clientAgent = $"smsapi-csharp-client:{Assembly.GetExecutingAssembly().GetName().Version};{Environment.Version}";
        }
        
        public abstract KeyValuePair<string, string> DefaultRequestHeaders { get; }

        public string GetClientAgent()
        {
            return _clientAgent;
        }
    }
}