using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    public class Countable
    {
        [JsonIgnore]
        private int _count;

        public Countable()
        {
        }

        protected Countable(int count = 0)
        {
            _count = count;
        }

        [JsonProperty("count")]
        public virtual int Count
        {
            get => _count;
            set => _count = value;
        }
    }
}
