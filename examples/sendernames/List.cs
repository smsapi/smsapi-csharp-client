using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var sendernames = features.Sendernames()
    .List()
    .Execute();

sendernames.Collection.ForEach(sendername =>
{
    Console.WriteLine($"Sender: {sendername.Sender}");
    Console.WriteLine($"Is default: {sendername.IsDefault}");
    Console.WriteLine($"Status: {sendername.Status}");
    Console.WriteLine($"Created at: {sendername.CreatedAt}");
});
