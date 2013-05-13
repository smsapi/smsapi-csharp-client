using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Groups : List
    {
        private Groups() : base() { }

        [DataMember(Name = "list", IsRequired = false)]
        private System.Collections.Generic.List<Group> list;

        public System.Collections.Generic.List<Group> List
        {
            get
            {
                if (list == null)
                    list = new System.Collections.Generic.List<Group>();

                return list;
            }

            set { }
        }
    }
}
