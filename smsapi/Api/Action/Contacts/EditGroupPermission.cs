using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class EditGroupPermission : Rest<SMSApi.Api.Response.GroupPermission>
	{
		public EditGroupPermission(string groupId, string username)
			: base()
		{
			GroupId = groupId;
			Username = username;
		}

		protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions/" + Username; } }

		protected override RequestMethod Method { get { return RequestMethod.PUT; } }

		protected override NameValueCollection Parameters
		{
			get
			{
				NameValueCollection parameters = base.Parameters;
				if (Read  != null) parameters.Add("read",  Convert.ToInt32(Read.Value).ToString());
				if (Write != null) parameters.Add("write", Convert.ToInt32(Write.Value).ToString());
				if (Send  != null) parameters.Add("send",  Convert.ToInt32(Send.Value).ToString());
				return parameters;
			}
		}

		private string groupId;
		public string GroupId { get { return groupId; } private set { groupId = value; } }

		private string username;
		public string Username { get { return username; } private set { username = value; } }

		public bool? Read;
		public EditGroupPermission SetRead(bool? read)
		{
			Read = read;
			return this;
		}

		public bool? Write;
		public EditGroupPermission SetWrite(bool? write)
		{
			Write = write;
			return this;
		}

		public bool? Send;
		public EditGroupPermission SetSend(bool? send)
		{
			Send = send;
			return this;
		}
	}
}
