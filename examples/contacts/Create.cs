using SMSApi.Api;
using SMSApi.Api.Response;
using smsapi.Api.Response.Contacts.Exception;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string phoneNumber = "4850010010";

try
{
    var contact = features.Contacts()
        .CreateContact()
        .SetPhoneNumber(phoneNumber)
        .SetFirstName("John") //optional
        .SetLastName("Doe") //optional
        .SetEmail("john.doe@example.com") //optional
        .SetGender(Contact.MaleGender) //optional
        .SetBirthdayDate(new DateTime(1990, 1, 31)) //optional
        .Execute();

    Console.WriteLine($"ID: {contact.Id}");
    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
    Console.WriteLine($"Created at: {contact.DateCreated}");
}
catch (ContactAlreadyExistsException ex)
{
    Console.WriteLine(ex.Message);
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
