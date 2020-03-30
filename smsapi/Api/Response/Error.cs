using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Error
    {
        public Error()
        {
            Code = "0";
            Message = "";
        }

        [DataMember(Name = "error", IsRequired = false)]
        public readonly string Code;

        [DataMember(Name = "message", IsRequired = true)]
        public readonly string Message;

        public bool isError()
        {
            return !string.IsNullOrEmpty(Code) && (Code != "0");
        }
    }
}
