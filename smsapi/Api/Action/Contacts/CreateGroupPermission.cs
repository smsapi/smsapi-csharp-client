using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class CreateGroupPermission : Rest<SMSApi.Api.Response.GroupPermission>
	{
		public CreateGroupPermission(string groupId)
			: base()
		{
			GroupId = groupId;
		}

		protected override string Resource { get { return "contacts/groups/" + GroupId + "/permissions"; } }

		protected override RequestMethod Method { get { return RequestMethod.POST; } }

		protected override NameValueCollection Parameters
		{
			get
			{
				NameValueCollection parameters = base.Parameters;
				if (Username != null) parameters.Add("username", Username);
				if (Read     != null) parameters.Add("read",     Convert.ToInt32(Read.Value).ToString());
				if (Write    != null) parameters.Add("write",    Convert.ToInt32(Write.Value).ToString());
				if (Send     != null) parameters.Add("send",     Convert.ToInt32(Send.Value).ToString());
				return parameters;
			}
		}

		private string groupId;
		public string GroupId { get { return groupId; } private set { groupId = value; } }

		public string Username;
		public CreateGroupPermission SetUsername(string username)
		{
			Username = username;
			return this;
		}

		public bool? Read;
		public CreateGroupPermission SetRead(bool? read)
		{
			Read = read;
			return this;
		}

		public bool? Write;
		public CreateGroupPermission SetWrite(bool? write)
		{
			Write = write;
			return this;
		}

		public bool? Send;
		public CreateGroupPermission SetSend(bool? send)
		{
			Send = send;
			return this;
		}
	}
}
