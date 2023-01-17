using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateContact : Base<Contact>
    {
        private DateTime? birthdayDate;
        private string city;
        private string description;
        private string email;
        private string firstName;
        private string gender;
        private string lastName;
        private string phoneNumber;
        private string source;

        protected override RequestMethod Method => RequestMethod.POST;

        public CreateContact SetBirthdayDate(DateTime birthdayDate)
        {
            this.birthdayDate = birthdayDate;
            return this;
        }

        public CreateContact SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public CreateContact SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public CreateContact SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public CreateContact SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public CreateContact SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public CreateContact SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public CreateContact SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public CreateContact SetSource(string source)
        {
            this.source = source;
            return this;
        }

        protected override string Uri()
        {
            return "contacts";
        }

        protected override NameValueCollection Values()
        {
            var values = new NameValueCollection();
            
            if (birthdayDate != null)
            {
                values.Add("birthday_date", birthdayDate.Value.ToString("yyyy-MM-dd"));
            }

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
