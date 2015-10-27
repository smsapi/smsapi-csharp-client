using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class Contact : Base
	{
		public const string MaleGender      = "male";
		public const string FemaleGender    = "female";
		public const string UndefinedGender = "undefined";

		public Contact() : base() { }

		[DataMember(Name = "id", IsRequired = false)]
		public readonly string Id;

		[DataMember(Name = "idx", IsRequired = false)]
		public readonly string Idx;

		[DataMember(Name = "first_name", IsRequired = false)]
		public readonly string FirstName;

		[DataMember(Name = "last_name", IsRequired = false)]
		public readonly string LastName;

		private DateTime? birthdayDate;

		[DataMember(Name = "birthday_date", IsRequired = false)]
		private string BirthdayDateSerializationHelper { set { if (value != null) birthdayDate = DateTime.Parse(value); } get { return ""; } }

		public DateTime? BirthdayDate { get { return birthdayDate; } }

		[DataMember(Name = "phone_number", IsRequired = false)]
		public readonly string PhoneNumber;

		[DataMember(Name = "email", IsRequired = false)]
		public readonly string Email;

		[DataMember(Name = "gender", IsRequired = false)]
		public readonly string Gender;

		[DataMember(Name = "city", IsRequired = false)]
		public readonly string City;

		[DataMember(Name = "source", IsRequired = false)]
		public readonly string Source;

		private DateTime? dateCreated;
		[DataMember(Name = "date_created", IsRequired = false)]
		private string DateCreatedSerializationHelper { set { dateCreated = DateTime.Parse(value); } get { return ""; } }
		public DateTime? DateCreated { get { return dateCreated; } }

		private DateTime? dateUpdated;
		[DataMember(Name = "date_updated", IsRequired = false)]
		private string DateUpdatedSerializationHelper { set { dateUpdated = DateTime.Parse(value); } get { return ""; } }
		public DateTime? DateUpdated { get { return dateUpdated; } }

		[DataMember(Name = "description", IsRequired = false)]
		public readonly string Description;

		[Obsolete("use Id instead")]
		[DataMember(Name = "number", IsRequired = false)]
		public readonly string Number;

		[Obsolete("use Description instead")]
		[DataMember(Name = "info", IsRequired = false)]
		public readonly string info;

		[Obsolete("use BirthdayDate instead")]
		[DataMember(Name = "birthday", IsRequired = false)]
		public readonly string Birthday;

		[DataMember(Name = "date_add", IsRequired = false)]
		private uint DateAddSerializationHelper { set { DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); dateCreated = origin.AddSeconds(value); } get { return 0; } }

		[Obsolete("use DateCreated instead")]
		public uint DateAdd { get { DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); return dateCreated != null ? (uint)(dateCreated.Value.ToUniversalTime() - origin).TotalSeconds : 0; } }

		[DataMember(Name = "date_mod", IsRequired = false)]
		private uint DateModSerializationHelper { set { DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); dateUpdated = origin.AddSeconds(value); } get { return 0; } }

		[Obsolete("use DateUpdated instead")]
		public uint DateMod { get { DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); return dateUpdated != null? (uint)(dateUpdated.Value.ToUniversalTime() - origin).TotalSeconds : 0; } }
	}
}
