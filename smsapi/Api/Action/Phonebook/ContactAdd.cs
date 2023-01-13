using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    [Obsolete("Use CreateContact")]
    public class PhonebookContactAdd : Base<Contact>
    {
        private int birthday;
        private string city;
        private string firstName;
        private string gender;
        private string[] groups;
        private string info;
        private string lastName;
        private string number;

        public PhonebookContactAdd SetBirthday(int birthday)
        {
            this.birthday = birthday;
            return this;
        }

        public PhonebookContactAdd SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public PhonebookContactAdd SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PhonebookContactAdd SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactAdd SetGroup(string group)
        {
            groups = new[] { group };
            return this;
        }

        public PhonebookContactAdd SetGroups(string[] groups)
        {
            this.groups = groups;
            return this;
        }

        public PhonebookContactAdd SetInfo(string info)
        {
            this.info = info;
            return this;
        }

        public PhonebookContactAdd SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PhonebookContactAdd SetNumber(string number)
        {
            this.number = number;
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
                { "add_contact", number }
            };

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
