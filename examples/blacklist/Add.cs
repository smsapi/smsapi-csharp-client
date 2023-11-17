using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string phoneNumber = "48500100100";

try
{
    var result = features.Blacklist()
        .Add(phoneNumber)
        .WithExpireAt(DateTimeOffset.Now)                       //Set expiration date (optional, DateTimeOffset)
        .WithExpireAt(DateTimeOffset.Now.ToUnixTimeSeconds())   //Set expiration date (optional, unixtimestamp)
        .Execute();

    Console.WriteLine($"ID: {result.Id}");
    Console.WriteLine($"Phone number: {result.PhoneNumber}");
    Console.WriteLine($"Created at: {result.DateCreated}");
    Console.WriteLine($"Expiring at: {result.DateExpired}");
}
catch (ValidationException exception)
{
    foreach (var validationErrorsError in exception.ValidationErrors.Errors)
    {
        Console.WriteLine(validationErrorsError.Message);
    }
}
