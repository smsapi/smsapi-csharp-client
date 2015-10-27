using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class Fields : BasicCollection<Field>
	{
		private Fields() : base() { }
	}
}
