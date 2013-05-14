using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Countable : Base
    {
        protected Countable()
            : base()
        {
            Count = 0;
        }

        [DataMember(Name = "count", IsRequired = true)]
        public readonly int Count;
    }
}
