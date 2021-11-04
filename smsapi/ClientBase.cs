using System;
using System.Diagnostics;
using System.Reflection;

namespace SMSApi.Api
{
    public abstract class ClientBase
    {
        private string _clientAgent;

        public ClientBase()
        {
            var assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            _clientAgent = string.Format(
                "smsapi/csharp-client:{0};assemblyFile:{1};.net:{2}",
                assembly.GetName().Version,
                fvi.FileVersion,
                Environment.Version);
        }

        public abstract string GetAuthenticationHeader();

        public string GetClientAgentHeader()
        {
            return _clientAgent;
        }
    }
}
