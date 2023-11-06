using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SMSApi.Api
{
    public readonly struct HttpResponseEntity
    {
        public readonly Task<Stream> Content;
        public readonly HttpStatusCode StatusCode;

        public HttpResponseEntity(Task<Stream> content, HttpStatusCode statusCode)
        {
            Content = content;
            StatusCode = statusCode;
        }
    }
}
