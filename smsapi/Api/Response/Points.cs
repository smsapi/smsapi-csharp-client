using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;
using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Credits : ErrorAwareResponse
    {
        [JsonProperty("ecoCount")]
        public readonly int EcoCount;

        [JsonProperty("mmsCount")]
        public readonly int MmsCount;

        [JsonRequired]
        [JsonProperty("points")]
        public readonly double Points;

        [JsonProperty("proCount")]
        public readonly int ProCount;

        [JsonProperty("vmsGsmCount")]
        public readonly int VmsGsmCount;

        [JsonProperty("vmsLandCount")]
        public readonly int VmsLandCount;

        private Credits()
        { }
    }
}
