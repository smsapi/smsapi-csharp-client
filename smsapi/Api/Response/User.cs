using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class User : ErrorAwareResponse
    {
        [DataMember(Name = "active", IsRequired = true)]
        public readonly bool Active;

        [DataMember(Name = "info", IsRequired = true)]
        public readonly string Info;

        [DataMember(Name = "limit", IsRequired = true)]
        public readonly double Limit;

        [DataMember(Name = "month_limit", IsRequired = true)]
        public readonly double MonthLimit;

        [DataMember(Name = "phonebook", IsRequired = true)]
        public readonly uint Phonebook;

        [DataMember(Name = "senders", IsRequired = true)]
        public readonly uint Senders;

        [DataMember(Name = "username", IsRequired = true)]
        public readonly string Username;

        private User()
        { }
    }
}
