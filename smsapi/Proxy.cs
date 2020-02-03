using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace SMSApi.Api 
{
    public enum RequestMethod { GET, POST, PUT, DELETE };

    public interface Proxy
	{
        Stream Execute(string uri, NameValueCollection data, RequestMethod method = RequestMethod.POST);
		Stream Execute(string uri, NameValueCollection data, Stream file, RequestMethod method = RequestMethod.POST);
		Stream Execute(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method = RequestMethod.POST);

        void Authentication(IClient client);
    }
}
