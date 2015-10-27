using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class EditField : Rest<SMSApi.Api.Response.Field>
	{
		public EditField(string fieldId)
			: base()
		{
			FieldId = fieldId;
		}

		protected override string Resource { get { return "contacts/fields/" + FieldId; } }

		protected override RequestMethod Method { get { return RequestMethod.PUT; } }

		protected override NameValueCollection Parameters
		{
			get
			{
				NameValueCollection parameters = base.Parameters;
				if (Name != null) parameters.Add("name", Name);
				return parameters;
			}
		}

		private string fieldId;
		public string FieldId { get { return fieldId; } private set { fieldId = value; } }

		public string Name;
		public EditField SetName(string name)
		{
			Name = name;
			return this;
		}
	}
}
