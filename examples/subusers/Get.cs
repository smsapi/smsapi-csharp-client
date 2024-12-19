using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

string subuserId = "593FAFB33361354EAF84E7A2";

try
{
    var createdSubuser = features.Subusers()
        .Get(subuserId)
        .Execute();

    Console.WriteLine($"SubuserId username: {createdSubuser.Username}");
    Console.WriteLine($"SubuserId status: {createdSubuser.Active}");
    Console.WriteLine($"SubuserId description: {createdSubuser.Description}");
    Console.WriteLine($"SubuserId points: {createdSubuser.Points}");
}
catch (NotFoundException)
{
}
