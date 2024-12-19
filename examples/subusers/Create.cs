using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

string username = $"new_subuser_{Random.Shared.Next()}";
string password = "<your_password>";

try
{
    var createdSubuser = features.Subusers()
        .Create(new SubuserCredentials(username, password))
        .AsActive() //optional
        .WithDescription("subuser description") //optional
        .WithPoints(new SubuserPoints(FromAccount: 10, PerMonth: 5)) //optional
        .Execute();

    Console.WriteLine($"Created subuser id: {createdSubuser.Id}");
    Console.WriteLine($"Created subuser username: {createdSubuser.Username}");
    Console.WriteLine($"Created subuser status: {createdSubuser.Active}");
    Console.WriteLine($"Created subuser description: {createdSubuser.Description}");
    Console.WriteLine($"Created subuser points: {createdSubuser.Points}");
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
