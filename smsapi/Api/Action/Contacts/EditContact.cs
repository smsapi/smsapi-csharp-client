using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditContact : Base<Contact>
    {
        private DateTime birthdayDate;
        private string city;
        private string description;
        private string email;
        private string firstName;
        private string gender;
        private string lastName;
        private string phoneNumber;
        private string source;

        public EditContact(string contactId)
        {
            ContactId = contactId;
        }

        public string ContactId { get; }

        protected override RequestMethod Method => RequestMethod.PUT;

        public EditContact SetBirthdayDate(DateTime birthdayDate)
        {
            this.birthdayDate = birthdayDate;
            return this;
        }

        public EditContact SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public EditContact SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public EditContact SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public EditContact SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public EditContact SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public EditContact SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public EditContact SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public EditContact SetSource(string source)
        {
            this.source = source;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/" + ContactId;
        }

        protected override NameValueCollection Values()
        {
            var values = new NameValueCollection
            {
                { "birthday_date", birthdayDate.ToString("Y-m-d") }
            };

            if (phoneNumber != null)
            {
                values.Add("phone_number", phoneNumber);
            }

            if (email != null)
            {
                values.Add("email", email);
            }

            if (firstName != null)
            {
                values.Add("first_name", firstName);
            }

            if (lastName != null)
            {
                values.Add("last_name", lastName);
            }

            if (gender != null)
            {
                values.Add("gender", gender);
            }

            if (description != null)
            {
                values.Add("description", description);
            }

            if (city != null)
            {
                values.Add("city", city);
            }

            if (source != null)
            {
                values.Add("source", source);
            }

            return values;
        }
    }
}
