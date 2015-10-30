using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class Field
	{
		public const string TextType        = "TEXT";
		public const string DateType        = "DATE";
		public const string EmailType       = "EMAIL";
		public const string PhoneNumberType = "PHONE_NUMBER";
		public const string NumberType      = "NUMBER";

		[DataMember(Name = "id", IsRequired = false)]
		public readonly string Id;

		[DataMember(Name = "name", IsRequired = false)]
		public readonly string Name;

		[DataMember(Name = "type", IsRequired = false)]
		public readonly string Type;
	}
}
