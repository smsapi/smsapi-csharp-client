using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Countable
    {
        private int count;

        protected Countable(int count = 0)
        {
            this.count = count;
        }

        [DataMember(Name = "count", IsRequired = false)]
        public virtual int Count
        {
            get => count;
            private set => count = value;
        }
    }
}
