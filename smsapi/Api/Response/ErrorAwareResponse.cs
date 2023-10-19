using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class ErrorAwareResponse
    {
        [DataMember(Name = "error", IsRequired = false)]
        public readonly int ErrorCode;

        [DataMember(Name = "message", IsRequired = false)]
        public readonly string ErrorMessage;
        
        public bool IsError() => ErrorCode != 0;
    }
}
