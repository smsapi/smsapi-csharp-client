using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class CheckNumber : Countable
    {
        protected CheckNumber() : base() { }

        [DataMember(Name = "list", IsRequired = true)]
        private List<NumberStatus> list;

        public List<NumberStatus> List
        {
            get
            {
                if (list == null)
                    list = new List<NumberStatus>();

                return list;
            }

            set { }
        }
    }
}
