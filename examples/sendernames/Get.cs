using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string existingSender = "sender";

try
{
    var createdSendername = features.Sendernames()
        .Get(existingSender)
        .Execute();

    Console.WriteLine(createdSendername.Sender);
    Console.WriteLine(createdSendername.Status);
    Console.WriteLine(createdSendername.IsDefault);
    Console.WriteLine(createdSendername.CreatedAt);
}
catch (NotFoundException)
{
}
