using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string contactId = "<contact_id>";

try
{
    var contact = features.Contacts()
        .GetContact(contactId)
        .Execute();

    Console.WriteLine($"ID: {contact.Id}");
    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
    Console.WriteLine($"First name: {contact.FirstName}");
    Console.WriteLine($"Last name: {contact.LastName}");
    Console.WriteLine($"Birthday: {contact.BirthdayDate}");
    Console.WriteLine($"Updated at: {contact.DateUpdated}");
}
catch (NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
