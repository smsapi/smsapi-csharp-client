using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Contacts : Countable
    {
        private Contacts() : base() { }

        [DataMember(Name = "list", IsRequired = true)]
        private System.Collections.Generic.List<Contact> list;

        public System.Collections.Generic.List<Contact> List
        {
            get
            {
                if (list == null)
                    list = new System.Collections.Generic.List<Contact>();

                return list;
            }

            set { }
        }

        [DataMember(Name = "total", IsRequired = false)]
        public readonly int Total;
    }
}
