using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class CheckNumber : List
    {
        protected CheckNumber() : base() { }

        [DataMember(Name = "list", IsRequired = false)]
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
