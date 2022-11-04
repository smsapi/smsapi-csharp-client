namespace SMSApi.Api
{
    public class ClientException : SmsapiException
    {
        public ClientException(string message, string code)
            : base(message, code)
        { }
    }
}
