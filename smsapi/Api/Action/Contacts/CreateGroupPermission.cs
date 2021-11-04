using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateGroupPermission : Rest<GroupPermission>
    {
        public bool? Read;

        public bool? Send;

        public string Username;

        public bool? Write;

        public CreateGroupPermission(string groupId)
        {
            GroupId = groupId;
        }

        public string GroupId { get; }

        protected override RequestMethod Method => RequestMethod.POST;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (Username != null)
                {
                    parameters.Add("username", Username);
                }

                if (Read != null)
                {
                    parameters.Add("read", Convert.ToInt32(Read.Value).ToString());
                }

                if (Write != null)
                {
                    parameters.Add("write", Convert.ToInt32(Write.Value).ToString());
                }

                if (Send != null)
                {
                    parameters.Add("send", Convert.ToInt32(Send.Value).ToString());
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts/groups/" + GroupId + "/permissions";

        public CreateGroupPermission SetRead(bool? read)
        {
            Read = read;
            return this;
        }

        public CreateGroupPermission SetSend(bool? send)
        {
            Send = send;
            return this;
        }

        public CreateGroupPermission SetUsername(string username)
        {
            Username = username;
            return this;
        }

        public CreateGroupPermission SetWrite(bool? write)
        {
            Write = write;
            return this;
        }
    }
}
