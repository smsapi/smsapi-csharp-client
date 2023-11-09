using System.Collections.Specialized;
using System.Globalization;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserEdit : Action<User>
    {
        private int active;
        private string info;
        private double limit;
        private double monthLimit;
        private string password;
        private string passwordApi;
        private int phonebook;
        private int senders;
        private string username;
        private bool withoutPrefix;

        protected override RequestMethod Method => RequestMethod.POST;

        public UserEdit()
        {
            limit = -1;
            monthLimit = -1;
            active = -1;
            phonebook = -1;
            senders = -1;
        }

        public UserEdit SetActive(bool flag)
        {
            active = flag ? 1 : 0;
            return this;
        }

        public UserEdit SetInfo(string text)
        {
            info = text;
            return this;
        }

        public UserEdit SetLimit(double limit)
        {
            this.limit = limit;
            return this;
        }

        public UserEdit SetMonthLimit(double limit)
        {
            monthLimit = limit;
            return this;
        }

        public UserEdit SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public UserEdit SetPasswordApi(string password)
        {
            passwordApi = password;
            return this;
        }

        public UserEdit SetPhonebook(int flag)
        {
            phonebook = flag;
            return this;
        }

        public UserEdit SetSenders(int flag)
        {
            senders = flag;
            return this;
        }

        public UserEdit SetWithoutPrefix(bool flag)
        {
            withoutPrefix = flag;
            return this;
        }

        public UserEdit Username(string username)
        {
            this.username = username;
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
                { "set_user", username }
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

            if (active >= 0)
            {
                collection.Add("active", active > 0 ? "1" : "0");
            }

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
