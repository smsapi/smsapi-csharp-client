using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    public class Countable
    {
        private int _count;

        public Countable()
        {
        }

        protected Countable(int count = 0)
        {
            this._count = count;
        }

        [JsonProperty("count")]
        public virtual int Count
        {
            get => _count;
            set => _count = value;
        }
    }
}
