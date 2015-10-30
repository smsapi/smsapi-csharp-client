using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class FieldOptions : BasicCollection<FieldOption>
	{
		private FieldOptions() : base() { }
	}
}
