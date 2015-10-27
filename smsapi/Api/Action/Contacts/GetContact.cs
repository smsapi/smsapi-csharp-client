using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class GetContact : Rest<SMSApi.Api.Response.Contact>
	{
		public GetContact(string contactId)
			: base()
		{
			ContactId = contactId;
		}

		protected override string Resource { get { return "contacts/" + ContactId; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }

		private string contactId;
		public string ContactId { get { return contactId; } private set { contactId = value; } }
	}
}
