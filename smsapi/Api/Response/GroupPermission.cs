using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class GroupPermission : Base
	{
		public GroupPermission() : base() { }

		[DataMember(Name = "group_id", IsRequired = false)]
		public readonly string GroupId;
	
		[DataMember(Name = "username", IsRequired = false)]
		public readonly string Username;

		[DataMember(Name = "write", IsRequired = false)]
		public readonly bool Write;

		[DataMember(Name = "read", IsRequired = false)]
		public readonly bool Read;

		[DataMember(Name = "send", IsRequired = false)]
		public readonly bool Send;
	}
}
