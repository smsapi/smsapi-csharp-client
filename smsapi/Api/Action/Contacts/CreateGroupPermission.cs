using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateGroupPermission : Base<GroupPermission>
    {
        private string groupId;
        private bool? read;
        private bool? send;
        private string username;
        private bool? write;

        public CreateGroupPermission(string groupId)
        {
            this.groupId = groupId;
        }

        public CreateGroupPermission SetRead(bool? read)
        {
            this.read = read;
            return this;
        }

        public CreateGroupPermission SetSend(bool? send)
        {
            this.send = send;
            return this;
        }

        public CreateGroupPermission SetUsername(string username)
        {
            this.username = username;
            return this;
        }

        public CreateGroupPermission SetWrite(bool? write)
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
            var values = new NameValueCollection();
            if (username != null)
            {
                values.Add("username", username);
            }

            if (read != null)
            {
                values.Add("read", Convert.ToInt32(read.Value).ToString());
            }

            if (write != null)
            {
                values.Add("write", Convert.ToInt32(write.Value).ToString());
            }

            if (send != null)
            {
                values.Add("send", Convert.ToInt32(send.Value).ToString());
            }

            return values;
        }
    }
}
