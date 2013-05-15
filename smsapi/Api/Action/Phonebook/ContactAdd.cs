using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactAdd : BaseSimple<SMSApi.Api.Response.Contact>
    {
        public PhonebookContactAdd() : base() { }

        protected override string Uri() { return "phonebook.do"; }

        protected string number;
        protected string firstName;
        protected string lastName;
        protected string info;
        protected int birthday;
        protected string city;
        protected string gender;
        protected string[] groups;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("add_contact", number);

            if (firstName != null)  collection.Add("first_name", firstName);
            if (lastName != null)   collection.Add("last_name", lastName);
            if (info != null)       collection.Add("info", info);
            if (birthday != 0)      collection.Add("birthday", birthday.ToString());
            if (city != null)       collection.Add("city", city);
            if (gender != null)     collection.Add("gender", gender);
            if (groups != null)     collection.Add("groups", string.Join(",", groups));

            return collection;
        }

        public PhonebookContactAdd SetNumber(string number)
        {
            this.number = number;
            return this;
        }

        public PhonebookContactAdd SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PhonebookContactAdd SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PhonebookContactAdd SetInfo(string info)
        {
            this.info = info;
            return this;
        }

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

        public PhonebookContactAdd SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactAdd SetGroup(string group)
        {
            this.groups = new string[] {group};
            return this;
        }

        public PhonebookContactAdd SetGroups(string[] groups)
        {
            this.groups = groups;
            return this;
        }
    }
}
