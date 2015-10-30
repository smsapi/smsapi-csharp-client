using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class BindContactToGroup : Rest<SMSApi.Api.Response.Base>
	{
		public BindContactToGroup(string contactId, string groupId)
			: base()
		{
			ContactId = contactId;
			GroupId = groupId;
		}

		protected override string Resource { get { return "contacts/" + contactId + "/groups/" + groupId; } }

		protected override RequestMethod Method { get { return RequestMethod.PUT; } }

		private string contactId;
		public string ContactId { get { return contactId; } private set { contactId = value; } }

		private string groupId;
		public string GroupId { get { return groupId; } private set { groupId = value; } }
	}
}
