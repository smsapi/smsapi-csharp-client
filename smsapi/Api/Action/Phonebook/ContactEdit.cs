using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactEdit : BaseSimple<SMSApi.Api.Response.Contact>
    {
        public PhonebookContactEdit() : base() { }

        protected override string Uri() { return "phonebook.do"; }

        protected string oldNumber;
        protected string newNumber;
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

            collection.Add("edit_contact", oldNumber);

            if (newNumber != null)  collection.Add("new_number", newNumber);
            if (firstName != null)  collection.Add("first_name", firstName);
            if (lastName != null)   collection.Add("last_name", lastName);
            if (info != null)       collection.Add("info", info);
            if (birthday != 0)      collection.Add("birthday", birthday.ToString());
            if (city != null)       collection.Add("city", city);
            if (gender != null)     collection.Add("gender", gender);
            if (groups != null)     collection.Add("groups", string.Join(",", groups));

            return collection;
        }

        public PhonebookContactEdit Number(string number)
        {
            this.oldNumber = number;
            return this;
        }

        public PhonebookContactEdit SetNumber(string number)
        {
            this.newNumber = number;
            return this;
        }

        public PhonebookContactEdit SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public PhonebookContactEdit SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public PhonebookContactEdit SetInfo(string info)
        {
            this.info = info;
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

        public PhonebookContactEdit SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public PhonebookContactEdit SetGroup(string group)
        {
            this.groups = new string[] {group};
            return this;
        }

        public PhonebookContactEdit SetGroups(string[] groups)
        {
            this.groups = groups;
            return this;
        }
    }
}
