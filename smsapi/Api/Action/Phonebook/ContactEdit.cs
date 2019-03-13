using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactEdit : BaseSimple<Response.Contact>
    {
        protected override string Uri()
        {
            return "phonebook.do";
        }

        private string _oldNumber;
        private string _newNumber;
        private string _firstName;
        private string _lastName;
        private string _info;
        private int _birthday;
        private string _city;
        private string _gender;
        private string[] _groups;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"edit_contact", _oldNumber}
            };




            if (_newNumber != null) collection.Add("new_number", _newNumber);
            if (_firstName != null) collection.Add("first_name", _firstName);
            if (_lastName != null) collection.Add("last_name", _lastName);
            if (_info != null) collection.Add("info", _info);
            if (_birthday != 0) collection.Add("birthday", _birthday.ToString());
            if (_city != null) collection.Add("city", _city);
            if (_gender != null) collection.Add("gender", _gender);
            if (_groups != null) collection.Add("groups", string.Join(",", _groups));

            return collection;
        }

        public PhonebookContactEdit Number(string number)
        {
            _oldNumber = number;
            return this;
        }

        public PhonebookContactEdit SetNumber(string number)
        {
            _newNumber = number;
            return this;
        }

        public PhonebookContactEdit SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public PhonebookContactEdit SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public PhonebookContactEdit SetInfo(string info)
        {
            _info = info;
            return this;
        }

        public PhonebookContactEdit SetBirthday(int birthday)
        {
            _birthday = birthday;
            return this;
        }

        public PhonebookContactEdit SetCity(string city)
        {
            _city = city;
            return this;
        }

        public PhonebookContactEdit SetGender(string gender)
        {
            _gender = gender;
            return this;
        }

        public PhonebookContactEdit SetGroup(string group)
        {
            _groups = new[] {group};
            return this;
        }

        public PhonebookContactEdit SetGroups(string[] groups)
        {
            _groups = groups;
            return this;
        }
    }
}