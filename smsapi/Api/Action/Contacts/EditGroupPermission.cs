using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditGroupPermission : Rest<GroupPermission>
    {
        public bool? Read;

        public bool? Send;

        public bool? Write;

        public EditGroupPermission(string groupId, string username)
        {
            GroupId = groupId;
            Username = username;
        }

        public string GroupId { get; private set; }

        public string Username { get; private set; }

        protected override RequestMethod Method => RequestMethod.PUT;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
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

        protected override string Resource => "contacts/groups/" + GroupId + "/permissions/" + Username;

        public EditGroupPermission SetRead(bool? read)
        {
            Read = read;
            return this;
        }

        public EditGroupPermission SetSend(bool? send)
        {
            Send = send;
            return this;
        }

        public EditGroupPermission SetWrite(bool? write)
        {
            Write = write;
            return this;
        }
    }
}
