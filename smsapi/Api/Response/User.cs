using System.Runtime.Serialization;
using Newtonsoft.Json;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class User : ErrorAwareResponse
    {
        [JsonRequired]
        public readonly bool Active;

        [JsonRequired]
        public readonly string Info;

        [JsonRequired]
        public readonly double Limit;

        [JsonRequired]
        public readonly double MonthLimit;

        [JsonRequired]
        public readonly uint Phonebook;

        [JsonRequired]
        public readonly uint Senders;

        [JsonRequired]
        public readonly string Username;

        private User()
        { }
    }
}
