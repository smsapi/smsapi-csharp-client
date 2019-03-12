using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class ListContactGroups : Rest<Response.Groups>
	{
		public ListContactGroups(string contactId)
        {
			ContactId = contactId;
		}

		protected override string Resource { get { return "contacts/" + ContactId + "/groups"; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }

		private string contactId;
		public string ContactId { get { return contactId; } private set { contactId = value; } }
	}
}
