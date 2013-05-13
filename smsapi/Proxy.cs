using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace SMSApi.Api 
{
    public interface Proxy
    {
        Stream Execute(string uri, NameValueCollection data);
        Stream Execute(string uri, NameValueCollection data, System.IO.Stream file);
        Stream Execute(string uri, NameValueCollection data, Dictionary<string, System.IO.Stream> files);
    }
}
