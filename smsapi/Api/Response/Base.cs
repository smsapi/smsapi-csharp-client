using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Base
    {
        [DataMember(Name = "error", IsRequired = false)]
        public readonly int ErrorCode;

        [DataMember(Name = "message", IsRequired = false)]
        public readonly string ErrorMessage;

        public Base()
        {
            ErrorCode = 0;
            ErrorMessage = "";
        }

        public bool isError()
        {
            return ErrorCode != 0;
        }
    }
}
