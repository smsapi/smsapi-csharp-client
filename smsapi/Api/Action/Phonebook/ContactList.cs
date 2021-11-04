using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookContactList : BaseSimple<Contacts>
    {
        protected string gender;
        protected string[] groups;
        protected uint limit;

        protected string number;
        protected uint offset;
        protected string orderBy;
        protected string orderDir;
        protected string searchText;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("list_contacts", "");

            if (number != null && number.Length > 0)
            {
                collection.Add("number", number);
            }

            if (groups != null && groups.Length > 0)
            {
                collection.Add("groups", string.Join(";", groups));
            }

            if (searchText != null && searchText.Length > 0)
            {
                collection.Add("text_search", searchText);
            }

            if (gender != null && gender.Length > 0)
            {
                collection.Add("gender", gender);
            }

            if (orderBy != null && orderBy.Length > 0)
            {
                collection.Add("order_by", orderBy);
            }

            if (orderDir != null && orderDir.Length > 0)
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
