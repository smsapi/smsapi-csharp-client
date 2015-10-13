using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace SMSApi.Api 
{
	public interface Proxy
	{
		Stream Execute(string uri, NameValueCollection data, string method = "POST");
		Stream Execute(string uri, NameValueCollection data, System.IO.Stream file, string method = "POST");
		Stream Execute(string uri, NameValueCollection data, Dictionary<string, System.IO.Stream> files, string method = "POST");
	}
}
