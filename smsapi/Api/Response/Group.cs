using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Group : Base
    {
        private Group() : base() { }

        [DataMember(Name = "name", IsRequired = false)]
        public readonly string Name;

        [DataMember(Name = "info", IsRequired = false)]
        public readonly string Info;

        [DataMember(Name = "numbers_count", IsRequired = false)]
        public readonly uint NumbersCount;
    }
}
