using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Credits : Base
    {
        private Credits() : base() { }

        [DataMember(Name = "points", IsRequired = true)]
        public readonly double Points;

        [DataMember(Name = "proCount", IsRequired = false)]
        public readonly int ProCount;
        [DataMember(Name = "ecoCount", IsRequired = false)]
        public readonly int EcoCount;
        [DataMember(Name = "mmsCount", IsRequired = false)]
        public readonly int MmsCount;
        [DataMember(Name = "vmsGsmCount", IsRequired = false)]
        public readonly int VmsGsmCount;
        [DataMember(Name = "vmsLandCount", IsRequired = false)]
        public readonly int VmsLandCount;
    }
}
