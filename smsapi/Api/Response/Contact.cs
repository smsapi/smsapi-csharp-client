using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using smsapi.Api.Response.Contacts.Exception;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response
{
    public class Contact : IResponseCodeAwareResolver
    {
        public const string FemaleGender = "female";
        public const string MaleGender = "male";
        public const string UndefinedGender = "undefined";

        [Obsolete("use BirthdayDate instead")]
        public readonly string Birthday;

        public readonly string City;

        public readonly string Description;

        public readonly string Email;

        public readonly string FirstName;

        public readonly string Gender;

        public readonly string Id;

        public readonly string Idx;

        [Obsolete("use Description instead")]
        public readonly string info;

        public readonly string LastName;

        [Obsolete("use Id instead")]
        public readonly string Number;

        public readonly string PhoneNumber;

        public readonly string Source;

        private DateTime? dateCreated;

        private DateTime? dateUpdated;

        public readonly DateTime BirthdayDate;

        public Dictionary<int, Action<Stream>> HandleExceptionActions()
        {
            return new Dictionary<int, Action<Stream>>
            {
                { 409, _ => throw new ContactAlreadyExistsException() }
            };
        }

        [Obsolete("use DateCreated instead")]
        [JsonIgnore]
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
        [JsonIgnore]
        public uint DateMod
        {
            get
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return dateUpdated != null ? (uint)(dateUpdated.Value.ToUniversalTime() - origin).TotalSeconds : 0;
            }
        }

        public DateTime? DateUpdated => dateUpdated;

        [JsonProperty("date_add")]
        private uint DateAddSerializationHelper
        {
            set
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                dateCreated = origin.AddSeconds(value);
            }
            get => 0;
        }

        [JsonProperty("date_created")]
        private string DateCreatedSerializationHelper
        {
            set => dateCreated = DateTime.Parse(value);
            get => "";
        }

        [JsonProperty("date_mod")]
        private uint DateModSerializationHelper
        {
            set
            {
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                dateUpdated = origin.AddSeconds(value);
            }
            get => 0;
        }

        [JsonProperty("date_updated")]
        private string DateUpdatedSerializationHelper
        {
            set => dateUpdated = DateTime.Parse(value);
            get => "";
        }
    }
}
