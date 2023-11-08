#nullable enable
namespace SMSApi.Api.Response.Deserialization
{
    public class DeserializationResult<T>
    {
        public T? Result;
        public ResponseError? ClientError;
        public ResponseError? HostError;
        public ResponseError? ActionError;
    }
    
    public readonly struct ResponseError
    {
        public readonly string Message;
        public readonly int Code;

        public ResponseError(string message, int code)
        {
            Message = message;
            Code = code;
        }
    }
}
