using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class Contacts : BasicCollection<Contact>
	{
		[Obsolete("")]
		[DataMember(Name = "total", IsRequired = false)]
		public readonly int Total;
	}
}
