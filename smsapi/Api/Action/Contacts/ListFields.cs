using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class ListFields : Rest<SMSApi.Api.Response.Fields>
	{
		public ListFields ()
			: base()
		{
		}

		protected override string Resource { get { return "contacts/fields"; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }
	}
}
