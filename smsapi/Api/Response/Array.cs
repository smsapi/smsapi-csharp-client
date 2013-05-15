using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Array<T> : Countable
    {
        protected Array() : base() { }

        public Array(System.Collections.Generic.List<T> list)
            : base(list.Count)
        {
            this.List = list;
        }

        [DataMember(Name = "list", IsRequired = true)]
        public readonly System.Collections.Generic.List<T> List;
    }
}
