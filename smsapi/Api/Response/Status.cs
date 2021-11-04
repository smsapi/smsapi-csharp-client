using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Status : Countable
    {
        [DataMember(Name = "length", IsRequired = false)]
        public readonly int? Length;

        [DataMember(Name = "message", IsRequired = false)]
        public readonly string Message;

        [DataMember(Name = "parts", IsRequired = false)]
        public readonly int? Parts;

        [DataMember(Name = "list", IsRequired = false)]
        private List<MessageStatus> list;

        private Status()
        { }

        public List<MessageStatus> List
        {
            get
            {
                if (list == null)
                {
                    list = new List<MessageStatus>();
                }

                return list;
            }

            set
            { }
        }
    }
}
