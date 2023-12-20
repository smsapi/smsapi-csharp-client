using SMSApi.Api;

namespace smsapi.Api.Response.Contacts.Exception;

public class ContactAlreadyExistsException : ClientException
{
    public ContactAlreadyExistsException() : base("Contact already exists", 409)
    {
    }
}
