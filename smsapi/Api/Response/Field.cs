using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response
{
    public class Field : IResponseCodeAwareResolver
    {
        public const string DateType = "DATE";
        public const string EmailType = "EMAIL";
        public const string NumberType = "NUMBER";
        public const string PhoneNumberType = "PHONE_NUMBER";
        public const string TextType = "TEXT";
        
        public readonly string Id;
        
        public readonly string Name;
        
        public readonly string Type;
    }
}
