using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    public class Sender
    {
        [JsonRequired]
        public readonly bool Default;

        [JsonRequired]
        [JsonProperty("sender")]
        public readonly string Name;

        [JsonRequired]
        public readonly string Status;
    }
}
