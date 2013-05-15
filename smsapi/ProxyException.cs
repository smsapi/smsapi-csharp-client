
namespace SMSApi.Api
{
    public class ProxyException : SMSApi.Api.Exception
    {
        public ProxyException(string message) : base(message) { }
        public ProxyException(string message, System.Exception inner) : base(message, inner) { }
    }
}
