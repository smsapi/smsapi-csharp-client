using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class GetGroupPermission : Rest<SMSApi.Api.Response.GroupPermission>
	{
		public GetGroupPermission(string groupId, string username)
			: base()
		{
			GroupId = groupId;
			Username = username;
		}

		protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions/" + Username; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }

		private string groupId;
		public string GroupId { get { return groupId; } private set { groupId = value; } }

		private string username;
		public string Username { get { return username; } private set { username = value; } }
	}
}
