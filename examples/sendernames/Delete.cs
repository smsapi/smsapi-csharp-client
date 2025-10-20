using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string senderToDelete = "sender";

try
{
    features.Sendernames()
        .Delete(senderToDelete)
        .Execute();

    //sendername is deleted at this point
}
catch (NotFoundException)
{
    Console.WriteLine("Sender not found");
}
