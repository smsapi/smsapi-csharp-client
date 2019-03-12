using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactList : BaseSimple<Response.Contacts>
    {
        public PhonebookContactList()
        {
            _offset = 0;
            _limit = 0;
        }

        protected override string Uri()
        {
            return "phonebook.do";
        }

        private string _number;
        private string[] _groups;
        private string _searchText;
        private string _gender;
        private string _orderBy;
        private string _orderDir;
        private uint _limit;
        private uint _offset;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"list_contacts", ""}
            };

            if (!string.IsNullOrEmpty(_number)) collection.Add("number", _number);
            if (_groups != null && _groups.Length > 0) collection.Add("groups", string.Join(";", _groups));
            if (!string.IsNullOrEmpty(_searchText)) collection.Add("text_search", _searchText);
            if (!string.IsNullOrEmpty(_gender)) collection.Add("gender", _gender);
            if (!string.IsNullOrEmpty(_orderBy)) collection.Add("order_by", _orderBy);
            if (!string.IsNullOrEmpty(_orderDir)) collection.Add("order_dir", _orderDir);
            if (_limit > 0) collection.Add("limit", _limit.ToString());
            if (_offset > 0) collection.Add("offset", _offset.ToString());

            return collection;
        }

        public PhonebookContactList Number(string number)
        {
            _number = number;
            return this;
        }

        public PhonebookContactList Group(string group)
        {
            _groups = new[] {group};
            return this;
        }

        public PhonebookContactList Groups(string[] groups)
        {
            _groups = groups;
            return this;
        }

        public PhonebookContactList Text(string text)
        {
            _searchText = text;
            return this;
        }

        public PhonebookContactList Gender(string gender)
        {
            _gender = gender;
            return this;
        }

        public PhonebookContactList OrderBy(string orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public PhonebookContactList OrderDir(string orderDir)
        {
            _orderDir = orderDir;
            return this;
        }

        public PhonebookContactList Limit(uint limit)
        {
            _limit = limit;
            return this;
        }

        public PhonebookContactList Offset(uint offset)
        {
            _offset = offset;
            return this;
        }
    }
}