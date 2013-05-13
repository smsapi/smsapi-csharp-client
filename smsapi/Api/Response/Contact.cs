using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Contact : Base
    {
        public Contact() : base() { }

        [DataMember(Name = "number", IsRequired = true)]
        public readonly string Number;

        [DataMember(Name = "first_name", IsRequired = true)]
        public readonly string FirstName;

        [DataMember(Name = "last_name", IsRequired = true)]
        public readonly string LastName;

        [DataMember(Name = "info", IsRequired = true)]
        public readonly string info;

        [DataMember(Name = "birthday", IsRequired = true)]
        public readonly string Birthday;

        [DataMember(Name = "city", IsRequired = true)]
        public readonly string City;

        [DataMember(Name = "gender", IsRequired = true)]
        public readonly string Gender;

        [DataMember(Name = "date_add", IsRequired = true)]
        public readonly int DateAdd;

        [DataMember(Name = "date_mod", IsRequired = true)]
        public readonly int DateMod;
    }
}
