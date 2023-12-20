using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListContacts : Action<Contacts>, IPaginable
    {
        private DateTime? birthdayDate;
        private string email;
        private string firstName;
        private string gender;
        private int? groupId;
        private string lastName;
        private int? limit;
        private int? offset;
        private string phoneNumber;
        private string search;

        protected override RequestMethod Method => RequestMethod.GET;

        protected override ApiType ApiType() => Action.ApiType.Rest;

        public ListContacts SetBirthdayDate(DateTime? birthdayDate)
        {
            this.birthdayDate = birthdayDate;
            return this;
        }

        public ListContacts SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public ListContacts SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public ListContacts SetGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public ListContacts SetGroupId(int? groupId)
        {
            this.groupId = groupId;
            return this;
        }

        public ListContacts SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public ListContacts SetLimit(int? limit)
        {
            this.limit = limit;
            return this;
        }

        public ListContacts SetOffset(int? offset)
        {
            this.offset = offset;
            return this;
        }

        public ListContacts SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public ListContacts SetSearch(string search)
        {
            this.search = search;
            return this;
        }

        protected override string Uri()
        {
            return "contacts";
        }

        protected override NameValueCollection Values()
        {
            var parameters = new NameValueCollection();
            if (search != null)
            {
                parameters.Add("q", search);
            }

            if (offset != null)
            {
                parameters.Add("offset", offset.Value.ToString());
            }

            if (limit != null)
            {
                parameters.Add("limit", limit.Value.ToString());
            }

            if (phoneNumber != null)
            {
                parameters.Add("phone_number", phoneNumber);
            }

            if (email != null)
            {
                parameters.Add("email", email);
            }

            if (firstName != null)
            {
                parameters.Add("first_name", firstName);
            }

            if (lastName != null)
            {
                parameters.Add("last_name", lastName);
            }

            if (groupId != null)
            {
                parameters.Add("group_id", groupId.Value.ToString());
            }

            if (gender != null)
            {
                parameters.Add("gender", gender);
            }

            if (birthdayDate != null)
            {
                parameters.Add("birthday_date", birthdayDate.Value.ToString("yyyy-MM-dd"));
            }

            return parameters;
        }

        public uint? Limit { get; set; }
        public uint? Offset { get; set; }
    }
}
