using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Credits : Base
    {
        private Credits() : base() { }

        [DataMember(Name = "points", IsRequired = true)]
        public readonly double Points;
    }
}
