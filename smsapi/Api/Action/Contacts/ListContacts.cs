using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListContacts : Rest<Contacts>
    {
        public DateTime? BirthdayDate;

        public string Email;

        public string FirstName;

        public string Gender;

        public int? GroupId;

        public string LastName;

        public int? Limit;

        public int? Offset;

        public string PhoneNumber;

        public string Search;

        protected override RequestMethod Method => RequestMethod.GET;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (Search != null)
                {
                    parameters.Add("q", Search);
                }

                if (Offset != null)
                {
                    parameters.Add("offset", Offset.Value.ToString());
                }

                if (Limit != null)
                {
                    parameters.Add("limit", Limit.Value.ToString());
                }

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

                if (GroupId != null)
                {
                    parameters.Add("group_id", GroupId.Value.ToString());
                }

                if (Gender != null)
                {
                    parameters.Add("gender", Gender);
                }

                if (BirthdayDate != null)
                {
                    parameters.Add("birthday_date", BirthdayDate.Value.ToString("Y-m-d"));
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts";

        public ListContacts SetBirthdayDate(DateTime? birthdayDate)
        {
            BirthdayDate = birthdayDate;
            return this;
        }

        public ListContacts SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public ListContacts SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public ListContacts SetGender(string gender)
        {
            Gender = gender;
            return this;
        }

        public ListContacts SetGroupId(int? groupId)
        {
            GroupId = groupId;
            return this;
        }

        public ListContacts SetLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public ListContacts SetLimit(int? limit)
        {
            Limit = limit;
            return this;
        }

        public ListContacts SetOffset(int? offset)
        {
            Offset = offset;
            return this;
        }

        public ListContacts SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public ListContacts SetSearch(string search)
        {
            Search = search;
            return this;
        }
    }
}
