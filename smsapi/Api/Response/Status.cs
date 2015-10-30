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

		[DataMember(Name = "message", IsRequired = false)]
		public readonly string Message;

		[DataMember(Name = "length", IsRequired = false)]
		public readonly int? Length;

		[DataMember(Name = "parts", IsRequired = false)]
		public readonly int? Parts;
    }
}
