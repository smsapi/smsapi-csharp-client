using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class BasicCollection<T> : Countable
	{
		protected BasicCollection() : base() { }

		[DataMember(Name = "size", IsRequired = false)]
		protected int size;

		public int Size { get { if (size == 0) return base.Count; return size; } }

		[DataMember(Name = "collection", IsRequired = false)]
		protected System.Collections.Generic.List<T> collection;

		[Obsolete("use Size instead")]
		public override int Count { get { return Size; } }

		public System.Collections.Generic.List<T> Collection
		{
			get
			{
				if (collection == null)
					collection = new System.Collections.Generic.List<T>();
				return collection;
			}

			set { }
		}

		[Obsolete("use Collection instead")]
		[DataMember(Name = "list", IsRequired = false)]
		public System.Collections.Generic.List<T> List { get { return Collection; } protected set { collection = value; } }
	}
}
