using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string newDefaultSender = "new sender2";

try
{
    features.Sendernames()
        .ChangeDefault(newDefaultSender)
        .Execute();

    //default sendername is changed at this point
}
catch (NotFoundException)
{
    Console.WriteLine("Sender not found");
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
