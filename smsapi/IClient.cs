using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSApi.Api
{
    public interface IClient
    {
        string GetAuthenticationHeader();
        string GetClientAgentHeader();
    }
}
