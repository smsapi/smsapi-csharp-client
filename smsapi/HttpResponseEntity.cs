using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SMSApi.Api
{
    public readonly struct HttpResponseEntity
    {
        private static readonly HttpStatusCode[] EmptyResponseCodes = { HttpStatusCode.Accepted, HttpStatusCode.NoContent };
        
        public readonly Task<Stream> Content;
        public readonly HttpStatusCode StatusCode;

        public bool IsEmptyContentCode => EmptyResponseCodes.Contains(StatusCode);

        public HttpResponseEntity(Task<Stream> content, HttpStatusCode statusCode)
        {
            Content = content;
            StatusCode = statusCode;
        }
    }
}
