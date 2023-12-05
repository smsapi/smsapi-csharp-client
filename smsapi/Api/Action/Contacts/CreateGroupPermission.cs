using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateGroupPermission : Action<GroupPermission>
    {
        private string groupId;
        private bool read;
        private bool send;
        private string username;
        private bool write;

        protected override RequestMethod Method => RequestMethod.POST;
        
        protected override ApiType ApiType() => Action.ApiType.Rest;

        protected override ActionContentType ContentType => ActionContentType.FormWww;

        public CreateGroupPermission(string groupId)
        {
            this.groupId = groupId;
        }

        public CreateGroupPermission SetRead(bool read)
        {
            this.read = read;
            return this;
        }

        public CreateGroupPermission SetSend(bool send)
        {
            this.send = send;
            return this;
        }

        public CreateGroupPermission SetUsername(string username)
        {
            this.username = username;
            return this;
        }

        public CreateGroupPermission SetWrite(bool write)
        {
            this.write = write;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/groups/" + groupId + "/permissions";
        }

        protected override NameValueCollection Values()
        {
            var values = new NameValueCollection
            {
                { "read", Convert.ToInt32(read).ToString() },
                { "write", Convert.ToInt32(write).ToString() },
                { "send", Convert.ToInt32(send).ToString() }
            };

            if (username != null)
            {
                values.Add("username", username);
            }

            return values;
        }
    }
}
