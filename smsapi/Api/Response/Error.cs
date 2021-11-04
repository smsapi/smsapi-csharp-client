using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Error
    {
        [DataMember(Name = "error", IsRequired = false)]
        public readonly string Code;

        [DataMember(Name = "message", IsRequired = true)]
        public readonly string Message;

        public Error()
        {
            Code = "0";
            Message = "";
        }

        public bool isError()
        {
            return !string.IsNullOrEmpty(Code) && Code != "0";
        }
    }
}
