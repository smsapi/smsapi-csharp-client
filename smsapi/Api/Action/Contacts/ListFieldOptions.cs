using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class ListFieldOptions : Rest<SMSApi.Api.Response.FieldOptions>
	{
		public ListFieldOptions(string fieldId)
			: base()
		{
			FieldId = fieldId;
		}

		protected override string Resource { get { return "contacts/fields/" + FieldId + "/options"; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }

		private string fieldId;
		public string FieldId { get { return fieldId; } private set { fieldId = value; } }
	}
}
