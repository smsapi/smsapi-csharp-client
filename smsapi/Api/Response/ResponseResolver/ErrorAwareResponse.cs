using System.Runtime.Serialization;

namespace SMSApi.Api.Response.ResponseResolver
{
    [DataContract]
    public class ErrorAwareResponse: IResponseCodeAwareResolver
    {
        [DataMember(Name = "error", IsRequired = false)]
        public readonly dynamic? ErrorCode;

        [DataMember(Name = "message", IsRequired = false)]
        public readonly string ErrorMessage;

        public bool IsError()
        {
            if (ErrorCode == null) return false;
                
            if (ErrorCode is string)
            {
                return ErrorCode != "";
            }

            return ErrorCode != 0;
        }
        
        public string GetErrorMessage() => ErrorMessage;
    }
}
