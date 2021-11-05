using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditGroupPermission : Base<GroupPermission>
    {
        private string groupId;
        private bool? read;
        private bool? send;
        private string username;
        private bool? write;

        public EditGroupPermission(string groupId, string username)
        {
            this.groupId = groupId;
            this.username = username;
        }

        protected override RequestMethod Method => RequestMethod.PUT;

        public EditGroupPermission SetRead(bool? read)
        {
            this.read = read;
            return this;
        }

        public EditGroupPermission SetSend(bool? send)
        {
            this.send = send;
            return this;
        }

        public EditGroupPermission SetWrite(bool? write)
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
            var parameters = new NameValueCollection();
            if (read != null)
            {
                parameters.Add("read", Convert.ToInt32(read.Value).ToString());
            }

            if (write != null)
            {
                parameters.Add("write", Convert.ToInt32(write.Value).ToString());
            }

            if (send != null)
            {
                parameters.Add("send", Convert.ToInt32(send.Value).ToString());
            }

            return parameters;
        }
    }
}
