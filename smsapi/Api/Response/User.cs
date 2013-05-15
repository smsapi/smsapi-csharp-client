using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class User : Base
    {
        private User() : base() { }

        [DataMember(Name = "username", IsRequired = true)]
        public readonly string Username;

        [DataMember(Name = "limit", IsRequired = true)]
        public readonly double Limit;

        [DataMember(Name = "month_limit", IsRequired = true)]
        public readonly double MonthLimit;

        [DataMember(Name = "senders", IsRequired = true)]
        public readonly uint Senders;

        [DataMember(Name = "phonebook", IsRequired = true)]
        public readonly uint Phonebook;

        [DataMember(Name = "active", IsRequired = true)]
        public readonly bool Active;

        [DataMember(Name = "info", IsRequired = true)]
        public readonly string Info;
    }
}
