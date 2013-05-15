using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Countable : Base
    {
        protected Countable(int count = 0)
            : base()
        {
            Count = count;
        }

        [DataMember(Name = "count", IsRequired = true)]
        public readonly int Count;
    }
}
