using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SMSApi.Api
{
    public abstract class ClientBase
    {
        private string _clientAgent;

        public ClientBase()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            
            _clientAgent = String.Format(
                "smsapi/csharp-client:{0};assemblyFile:{1};.net:{2}",
                assembly.GetName().Version.ToString(),
                fvi.FileVersion,
                Environment.Version.ToString());
        }

        public string GetClientAgentHeader()
        {
            return _clientAgent;
        }

        public abstract string GetAuthenticationHeader();
    }
}
