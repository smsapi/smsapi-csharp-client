using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class GroupPermissions : BasicCollection<GroupPermission>
	{
		private GroupPermissions() : base() { }
	}
}
