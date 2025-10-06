using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string newSender = "new sender";

try
{
    var createdSendername = features.Sendernames()
        .Create(newSender)
        .Execute();

    Console.WriteLine(createdSendername.Sender);
    Console.WriteLine(createdSendername.Status);
    Console.WriteLine(createdSendername.IsDefault);
    Console.WriteLine(createdSendername.CreatedAt);
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
