using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response
{
    public class BasicCollection<T> : Countable, IResponseCodeAwareResolver
    {
        protected List<T> collection;
        
        [JsonProperty("size")]
        private int _size;

        public List<T> Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = new List<T>();
                }

                return collection;
            }

            set
            { }
        }

        [Obsolete("use Size instead")]
        [JsonIgnore]
        public override int Count => Size;

        [Obsolete("use Collection instead")]
        [JsonProperty("list")]
        public List<T> List
        {
            get => Collection;
            protected set => collection = value;
        }

        [JsonIgnore]
        public int Size
        {
            get
            {
                if (_size == 0)
                {
                    return base.Count;
                }

                return _size;
            }
        }
    }
}
