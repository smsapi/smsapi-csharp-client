using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Status : Countable
    {
        private Status() : base() { }

        [DataMember(Name = "list", IsRequired = false)]
        private List<MessageStatus> list;

        public List<MessageStatus> List
        {
            get
            {
                if (list == null)
                    list = new List<MessageStatus>();

                return list;
            }

            set { }
        }
    }
}
