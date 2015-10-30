using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class ListGroupPermissions : Rest<SMSApi.Api.Response.GroupPermissions>
	{
		public ListGroupPermissions(string groupId)
			: base()
		{
			GroupId = groupId;
		}

		protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions"; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }

		private string groupId;
		public string GroupId { get { return groupId; } private set { groupId = value; } }
	}
}
