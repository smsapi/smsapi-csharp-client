using System;
using System.Reflection;
using RestSharp.Authenticators;

namespace SMSApi.Api
{
    public abstract class ClientBase : IClient
    {
        private readonly string _clientAgent;

        protected ClientBase()
        {
            _clientAgent = $"smsapi-csharp-client:{Assembly.GetExecutingAssembly().GetName().Version};{Environment.Version}";
        }

        public abstract IAuthenticator Authenticator { get; }

        public string GetClientAgent()
        {
            return _clientAgent;
        }
    }
}