using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditGroupPermission : Action<GroupPermission>
    {
        private string groupId;
        private bool read;
        private bool send;
        private string username;
        private bool write;

        public EditGroupPermission(string groupId, string username)
        {
            this.groupId = groupId;
            this.username = username;
        }

        protected override RequestMethod Method => RequestMethod.PUT;

        public EditGroupPermission SetRead(bool read)
        {
            this.read = read;
            return this;
        }

        public EditGroupPermission SetSend(bool send)
        {
            this.send = send;
            return this;
        }

        public EditGroupPermission SetWrite(bool write)
        {
            this.write = write;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/groups/" + groupId + "/permissions/" + username;
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "read", Convert.ToInt32(read).ToString() },
                { "write", Convert.ToInt32(write).ToString() },
                { "send", Convert.ToInt32(send).ToString() }
            };
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("GroupId cannot be empty");
            }
        }
    }
}
