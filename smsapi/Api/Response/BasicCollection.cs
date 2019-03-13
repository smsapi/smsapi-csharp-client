using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class BasicCollection<T> : Countable
    {
        protected BasicCollection()
        {
        }

        [DataMember(Name = "size", IsRequired = false)]
        protected int size;

        public int Size => size == 0 ? base.Count : size;

        [DataMember(Name = "collection", IsRequired = false)]
        protected System.Collections.Generic.List<T> collection;

        [Obsolete("use Size instead")]
        public override int Count => Size;

        public System.Collections.Generic.List<T> Collection
        {
            get => collection ?? (collection = new System.Collections.Generic.List<T>());

            set { }
        }

        [Obsolete("use Collection instead")]
        [DataMember(Name = "list", IsRequired = false)]
        public System.Collections.Generic.List<T> List
        {
            get => Collection;
            protected set => collection = value;
        }
    }
}