using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Contact : ErrorAwareResponse
    {
        public const string FemaleGender = "female";
        public const string MaleGender = "male";
        public const string UndefinedGender = "undefined";

        [Obsolete("use BirthdayDate instead")]
        [DataMember(Name = "birthday", IsRequired = false)]
        public readonly string Birthday;

        [DataMember(Name = "city", IsRequired = false)]
        public readonly string City;

        [DataMember(Name = "description", IsRequired = false)]
        public readonly string Description;

        [DataMember(Name = "email", IsRequired = false)]
        public readonly string Email;

        [DataMember(Name = "first_name", IsRequired = false)]
        public readonly string FirstName;

        [DataMember(Name = "gender", IsRequired = false)]
        public readonly string Gender;

        [DataMember(Name = "id", IsRequired = false)]
        public readonly string Id;

        [DataMember(Name = "idx", IsRequired = false)]
        public readonly string Idx;

        [Obsolete("use Description instead")]
        [DataMember(Name = "info", IsRequired = false)]
        public readonly string info;

        [DataMember(Name = "last_name", IsRequired = false)]
        public readonly string LastName;

        [Obsolete("use Id instead")]
        [DataMember(Name = "number", IsRequired = false)]
        public readonly string Number;

        [DataMember(Name = "phone_number", IsRequired = false)]
        public readonly string PhoneNumber;

        [DataMember(Name = "source", IsRequired = false)]
        public readonly string Source;

        private DateTime? dateCreated;

        private DateTime? dateUpdated;

        public DateTime? BirthdayDate { get; private set; }

        [Obsolete("use DateCreated instead")]
        public uint DateAdd
        {
            get
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return dateCreated != null ? (uint)(dateCreated.Value.ToUniversalTime() - origin).TotalSeconds : 0;
            }
        }

        public DateTime? DateCreated => dateCreated;

        [Obsolete("use DateUpdated instead")]
        public uint DateMod
        {
            get
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return dateUpdated != null ? (uint)(dateUpdated.Value.ToUniversalTime() - origin).TotalSeconds : 0;
            }
        }

        public DateTime? DateUpdated => dateUpdated;

        [DataMember(Name = "birthday_date", IsRequired = false)]
        private string BirthdayDateSerializationHelper
        {
            set
            {
                if (value != null)
                {
                    BirthdayDate = DateTime.Parse(value);
                }
            }
            get => "";
        }

        [DataMember(Name = "date_add", IsRequired = false)]
        private uint DateAddSerializationHelper
        {
            set
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                dateCreated = origin.AddSeconds(value);
            }
            get => 0;
        }

        [DataMember(Name = "date_created", IsRequired = false)]
        private string DateCreatedSerializationHelper
        {
            set => dateCreated = DateTime.Parse(value);
            get => "";
        }

        [DataMember(Name = "date_mod", IsRequired = false)]
        private uint DateModSerializationHelper
        {
            set
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                dateUpdated = origin.AddSeconds(value);
            }
            get => 0;
        }

        [DataMember(Name = "date_updated", IsRequired = false)]
        private string DateUpdatedSerializationHelper
        {
            set => dateUpdated = DateTime.Parse(value);
            get => "";
        }
    }
}
