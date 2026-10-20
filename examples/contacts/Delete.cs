using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string contactId = "<contact_id>";

try
{
    features.Contacts()
        .DeleteContact(contactId)
        .Execute();

    //contact is deleted at this point
    Console.WriteLine($"Deleted contact {contactId}");
}
catch (NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
