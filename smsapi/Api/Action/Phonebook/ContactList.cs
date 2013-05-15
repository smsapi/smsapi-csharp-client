using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactList : BaseSimple<SMSApi.Api.Response.Contacts>
    {
        public PhonebookContactList() 
            : base() 
        {
            offset = 0;
            limit = 0;
        }

        protected override string Uri() { return "phonebook.do"; }

        protected string number;
        protected string[] groups;
        protected string searchText;
        protected string gender;
        protected string orderBy;
        protected string orderDir;
        protected uint limit;
        protected uint offset;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("list_contacts", "");

            if (number != null && number.Length > 0) collection.Add("number", number);
            if (groups != null && groups.Length > 0) collection.Add("groups", string.Join(";", groups));
            if (searchText != null && searchText.Length > 0) collection.Add("text_search", searchText);
            if (gender != null && gender.Length > 0) collection.Add("gender", gender);
            if (orderBy != null && orderBy.Length > 0) collection.Add("order_by", orderBy);
            if (orderDir != null && orderDir.Length > 0) collection.Add("order_dir", orderDir);
            if (limit > 0) collection.Add("limit", limit.ToString());
            if (offset > 0) collection.Add("offset", offset.ToString());

            return collection;
        }

        public PhonebookContactList Number(string number)
        {
            this.number = number;
            return this;
        }

        public PhonebookContactList Group(string group)
        {
            this.groups = new string[] { group };
            return this;
        }

        public PhonebookContactList Groups(string[] groups)
        {
            this.groups = groups;
            return this;
        }

        public PhonebookContactList Text(string text)
        {
            this.searchText = text;
            return this;
        }

        public PhonebookContactList Gender(string gender)
        {
            this.gender = gender;
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

        public PhonebookContactList Limit(uint limit)
        {
            this.limit = limit;
            return this;
        }

        public PhonebookContactList Offset(uint offset)
        {
            this.offset = offset;
            return this;
        }
    }
}
