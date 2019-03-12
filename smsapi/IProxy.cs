using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;

namespace SMSApi.Api
{
    public enum RequestMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    };

    public interface IProxy
    {
        Stream Execute(string uri, NameValueCollection data, RequestMethod method = RequestMethod.POST);
        Stream Execute(string uri, NameValueCollection data, Stream file, RequestMethod method = RequestMethod.POST);
        Stream Execute(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method = RequestMethod.POST);

        void BasicAuthentication(Client client);

#if !NET40
        Task<Stream> ExecuteAsync(string uri, NameValueCollection data, RequestMethod method = RequestMethod.POST);
        Task<Stream> ExecuteAsync(string uri, NameValueCollection data, Stream file, RequestMethod method = RequestMethod.POST);
        Task<Stream> ExecuteAsync(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method = RequestMethod.POST);
#endif
    }
}