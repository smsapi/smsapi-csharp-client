using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class Countable /*: Base*/
	{
		protected Countable(int count = 0) : base()
		{
		    this.count = count;
		}

		private int count;

		[DataMember(Name = "count", IsRequired = false)]
		public virtual int Count { get { return count; } private set { count = value; } }
	}
}
