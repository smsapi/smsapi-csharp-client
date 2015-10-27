using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
	public class ListContacts : Rest<Response.Contacts>
	{
		public ListContacts ()
			: base()
		{
		}

		protected override string Resource { get { return "contacts"; } }

		protected override RequestMethod Method { get { return RequestMethod.GET; } }

		protected override NameValueCollection Parameters
		{
			get
			{
				NameValueCollection parameters = base.Parameters;
				if (Search       != null) parameters.Add("q",             Search);
				if (Offset       != null) parameters.Add("offset",        Offset.Value.ToString());
				if (Limit        != null) parameters.Add("limit",         Limit.Value.ToString());
				if (PhoneNumber  != null) parameters.Add("phone_number",  PhoneNumber);
				if (Email        != null) parameters.Add("email",         Email);
				if (FirstName    != null) parameters.Add("first_name",    FirstName);
				if (LastName     != null) parameters.Add("last_name",     LastName);
				if (GroupId      != null) parameters.Add("group_id",      GroupId.Value.ToString());
				if (Gender       != null) parameters.Add("gender",        Gender);
				if (BirthdayDate != null) parameters.Add("birthday_date", BirthdayDate.Value.ToString("Y-m-d"));
				return parameters;
			}
		}

		public string Search;
		public ListContacts SetSearch(string search)
		{
			Search = search;
			return this;
		}

		public int? Offset;
		public ListContacts SetOffset(int? offset)
		{
			Offset = offset;
			return this;
		}

		public int? Limit;
		public ListContacts SetLimit(int? limit)
		{
			Limit = limit;
			return this;
		}

		public string PhoneNumber;
		public ListContacts SetPhoneNumber(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
			return this;
		}

		public string Email;
		public ListContacts SetEmail(string email)
		{
			Email = email;
			return this;
		}

		public string FirstName;
		public ListContacts SetFirstName(string firstName)
		{
			FirstName = firstName;
			return this;
		}

		public string LastName;
		public ListContacts SetLastName(string lastName)
		{
			LastName = lastName;
			return this;
		}

		public int? GroupId;
		public ListContacts SetGroupId(int? groupId)
		{
			GroupId = groupId;
			return this;
		}

		public string Gender;
		public ListContacts SetGender(string gender)
		{
			Gender = gender;
			return this;
		}

		public DateTime? BirthdayDate;
		public ListContacts SetBirthdayDate(DateTime? birthdayDate)
		{
			BirthdayDate = birthdayDate;
			return this;
		}
	}
}
