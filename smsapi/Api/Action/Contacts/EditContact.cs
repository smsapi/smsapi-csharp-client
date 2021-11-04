using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditContact : Rest<Contact>
    {
        public DateTime? BirthdayDate;

        public string City;

        public string Description;

        public string Email;

        public string FirstName;

        public string Gender;

        public string LastName;

        public string PhoneNumber;

        public string Source;

        public EditContact(string contactId)
        {
            ContactId = contactId;
        }

        public string ContactId { get; }

        protected override RequestMethod Method => RequestMethod.PUT;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (PhoneNumber != null)
                {
                    parameters.Add("phone_number", PhoneNumber);
                }

                if (Email != null)
                {
                    parameters.Add("email", Email);
                }

                if (FirstName != null)
                {
                    parameters.Add("first_name", FirstName);
                }

                if (LastName != null)
                {
                    parameters.Add("last_name", LastName);
                }

                if (Gender != null)
                {
                    parameters.Add("gender", Gender);
                }

                if (BirthdayDate != null)
                {
                    parameters.Add("birthday_date", BirthdayDate.Value.ToString("Y-m-d"));
                }

                if (Description != null)
                {
                    parameters.Add("description", Description);
                }

                if (City != null)
                {
                    parameters.Add("city", City);
                }

                if (Source != null)
                {
                    parameters.Add("source", Source);
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts/" + ContactId;

        public EditContact SetBirthdayDate(DateTime? birthdayDate)
        {
            BirthdayDate = birthdayDate;
            return this;
        }

        public EditContact SetCity(string city)
        {
            City = city;
            return this;
        }

        public EditContact SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public EditContact SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public EditContact SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public EditContact SetGender(string gender)
        {
            Gender = gender;
            return this;
        }

        public EditContact SetLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public EditContact SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public EditContact SetSource(string source)
        {
            Source = source;
            return this;
        }
    }
}
