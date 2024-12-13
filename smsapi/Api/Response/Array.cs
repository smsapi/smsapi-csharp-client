using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Array<T> : Countable
    {
        public readonly List<T> List;

        public Array(List<T> list)
            : base(list.Count)
        {
            List = list;
        }

        protected Array()
        { }
    }
}
