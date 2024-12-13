using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Senders : Countable
    {
        [JsonProperty("list")]
        private List<Sender> list;

        private Senders()
        { }

        public List<Sender> List
        {
            get
            {
                if (list == null)
                {
                    list = new List<Sender>();
                }

                return list;
            }

            set
            { }
        }
    }
}
