using System.Collections.Generic;

namespace SMSApi.Api
{
    public interface IClient
    {
        KeyValuePair<string, string> DefaultRequestHeaders { get; }
        
        string GetClientAgent();
    }
}
