using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookContactList : Base<Contacts>
    {
        private string gender;
        private string[] groups;
        private uint limit;
        private string number;
        private uint offset;
        private string orderBy;
        private string orderDir;
        private string searchText;

        public PhonebookContactList()
        {
            offset = 0;
            limit = 0;
        }

        public PhonebookContactList Gender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactList Group(string group)
        {
            groups = new[] { group };
            return this;
        }

        public PhonebookContactList Groups(string[] groups)
        {
            this.groups = groups;
            return this;
        }

        public PhonebookContactList Limit(uint limit)
        {
            this.limit = limit;
            return this;
        }

        public PhonebookContactList Number(string number)
        {
            this.number = number;
            return this;
        }

        public PhonebookContactList Offset(uint offset)
        {
            this.offset = offset;
            return this;
        }

        public PhonebookContactList OrderBy(string orderBy)
        {
            this.orderBy = orderBy;
            return this;
        }

        public PhonebookContactList OrderDir(string orderDir)
        {
            this.orderDir = orderDir;
            return this;
        }

        public PhonebookContactList Text(string text)
        {
            searchText = text;
            return this;
        }

        protected override string Uri()
        {
            return "phonebook.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                { "format", "json" },
                { "list_contacts", "" }
            };

            if (!string.IsNullOrEmpty(number))
            {
                collection.Add("number", number);
            }

            if (groups?.Length > 0)
            {
                collection.Add("groups", string.Join(";", groups));
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                collection.Add("text_search", searchText);
            }

            if (!string.IsNullOrEmpty(gender))
            {
                collection.Add("gender", gender);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                collection.Add("order_by", orderBy);
            }

            if (!string.IsNullOrEmpty(orderDir))
            {
                collection.Add("order_dir", orderDir);
            }

            if (limit > 0)
            {
                collection.Add("limit", limit.ToString());
            }

            if (offset > 0)
            {
                collection.Add("offset", offset.ToString());
            }

            return collection;
        }
    }
}
