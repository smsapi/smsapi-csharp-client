using System.Collections.Specialized;
using System.Globalization;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserAdd : Base<User>
    {
        private bool active;
        private string info;
        private double limit;
        private double monthLimit;
        private string newUsername;
        private string password;
        private string passwordApi;
        private int phonebook;
        private int senders;
        private bool withoutPrefix;

        protected override RequestMethod Method => RequestMethod.POST;

        public UserAdd()
        {
            limit = -1;
            monthLimit = -1;
            active = false;
            phonebook = -1;
            senders = -1;
        }

        public UserAdd SetActive(bool flag)
        {
            active = flag;
            return this;
        }

        public UserAdd SetInfo(string text)
        {
            info = text;
            return this;
        }

        public UserAdd SetLimit(double limit)
        {
            this.limit = limit;
            return this;
        }

        public UserAdd SetMonthLimit(double limit)
        {
            monthLimit = limit;
            return this;
        }

        public UserAdd SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public UserAdd SetPasswordApi(string password)
        {
            passwordApi = password;
            return this;
        }

        public UserAdd SetPhonebook(int flag)
        {
            phonebook = flag;
            return this;
        }

        public UserAdd SetSenders(int flag)
        {
            senders = flag;
            return this;
        }

        public UserAdd SetUsername(string username)
        {
            newUsername = username;
            return this;
        }

        public UserAdd SetWithoutPrefix(bool flag)
        {
            withoutPrefix = flag;
            return this;
        }

        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                { "add_user", newUsername }
            };

            if (password != null)
            {
                collection.Add("pass", password);
            }

            if (passwordApi != null)
            {
                collection.Add("pass_api", passwordApi);
            }

            if (limit >= 0)
            {
                collection.Add("limit", limit.ToString(CultureInfo.InvariantCulture));
            }

            if (monthLimit >= 0)
            {
                collection.Add("month_limit", monthLimit.ToString(CultureInfo.InvariantCulture));
            }

            if (senders >= 0)
            {
                collection.Add("senders", senders.ToString());
            }

            if (phonebook >= 0)
            {
                collection.Add("phonebook", phonebook.ToString());
            }

            collection.Add("active", active ? "1" : "0");
            if (info != null)
            {
                collection.Add("info", info);
            }

            if (withoutPrefix)
            {
                collection.Add("without_prefix", "1");
            }

            return collection;
        }
    }
}
