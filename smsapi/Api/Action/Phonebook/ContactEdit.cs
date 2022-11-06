using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookContactEdit : Base<Contact>
    {
        private int birthday;
        private string city;
        private string firstName;
        private string gender;
        private string[] groups;
        private string info;
        private string lastName;
        private string newNumber;
        private string oldNumber;

        public PhonebookContactEdit Number(string number)
        {
            oldNumber = number;
            return this;
        }

        public PhonebookContactEdit SetBirthday(int birthday)
        {
            this.birthday = birthday;
            return this;
        }

        public PhonebookContactEdit SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public PhonebookContactEdit SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PhonebookContactEdit SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactEdit SetGroup(string group)
        {
            groups = new[] { group };
            return this;
        }

        public PhonebookContactEdit SetGroups(string[] groups)
        {
            this.groups = groups;
            return this;
        }

        public PhonebookContactEdit SetInfo(string info)
        {
            this.info = info;
            return this;
        }

        public PhonebookContactEdit SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PhonebookContactEdit SetNumber(string number)
        {
            newNumber = number;
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
                { "edit_contact", oldNumber }
            };

            if (newNumber != null)
            {
                collection.Add("new_number", newNumber);
            }

            if (firstName != null)
            {
                collection.Add("first_name", firstName);
            }

            if (lastName != null)
            {
                collection.Add("last_name", lastName);
            }

            if (info != null)
            {
                collection.Add("info", info);
            }

            if (birthday != 0)
            {
                collection.Add("birthday", birthday.ToString());
            }

            if (city != null)
            {
                collection.Add("city", city);
            }

            if (gender != null)
            {
                collection.Add("gender", gender);
            }

            if (groups != null)
            {
                collection.Add("groups", string.Join(",", groups));
            }

            return collection;
        }
    }
}
