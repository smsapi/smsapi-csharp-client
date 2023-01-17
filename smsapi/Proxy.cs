using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;

namespace SMSApi.Api
{
    public interface Proxy
    {
        void Authentication(IClient client);

        Stream Execute(
            string uri,
            NameValueCollection data,
            RequestMethod method);

        Stream Execute(
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method);

        Stream Execute(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method);

        Task<Stream> ExecuteAsync(
            string uri,
            NameValueCollection data,
            RequestMethod method);

        Task<Stream> ExecuteAsync(
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method);

        Task<Stream> ExecuteAsync(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method);
    }
}
