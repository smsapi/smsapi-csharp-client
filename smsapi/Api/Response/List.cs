using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class List : Base
    {
        protected List()
            : base()
        {
            Count = 0;
        }

        [DataMember(Name = "count", IsRequired = false)]
        public readonly int Count;
    }
}
