using System;
using System.Collections.Generic;
using System.Reflection;

namespace SMSApi.Api
{
    public abstract class ClientBase : IClient
    {
        private readonly string _clientAgent = $"smsapi-csharp-client/{Assembly.GetExecutingAssembly().GetName().Version} {Environment.Version}";

        public abstract KeyValuePair<string, string> DefaultRequestHeaders { get; }

        public string GetClientAgent()
        {
            return _clientAgent;
        }
    }
}
