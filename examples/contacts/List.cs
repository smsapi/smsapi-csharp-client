using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var list = features.Contacts().ListContacts();

list.Limit = 25;
list.Offset = 0;

var contacts = list
    .SetSearch("John") //Search by any field (optional)
    //.SetGroupId("<group_id>") //Filter by group (optional)
    .Execute();

Console.WriteLine($"Total: {contacts.Size}");

contacts.Collection.ForEach(contact =>
{
    Console.WriteLine($"ID: {contact.Id}");
    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
    Console.WriteLine($"First name: {contact.FirstName}");
    Console.WriteLine($"Last name: {contact.LastName}");
    Console.WriteLine($"Email: {contact.Email}");
});
