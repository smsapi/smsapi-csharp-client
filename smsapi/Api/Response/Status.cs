using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Status : Countable
    {
        [JsonProperty("length")]
        public readonly int? Length;

        [JsonProperty("message")]
        public readonly string Message;

        [JsonProperty("parts")]
        public readonly int? Parts;

        [JsonProperty("fallbacks")] public Dictionary<string, Fallback>? Fallbacks = default;

        [JsonProperty("list")]
        private List<MessageStatus> list;
        
        [DataContract]
        public class Fallback : Countable
        {
            [JsonProperty("list")]
            public List<FallbackItem> List { get; set; } = new List<FallbackItem>();
        }

        [DataContract]
        public class FallbackItem
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("idx")]
            public string Idx { get; set; }  // Note: Adjust type if 'idx' can be numeric

            [JsonProperty("date_sent")]
            public long DateSent { get; set; }  // Ensure the timestamp format is handled correctly

            [JsonProperty("points")]
            public double Points { get; set; }
        }
    
        public List<MessageStatus> List
        {
            get
            {
                if (list == null)
                {
                    list = new List<MessageStatus>();
                }

                return list;
            }

            set
            { }
        }
    }
}
