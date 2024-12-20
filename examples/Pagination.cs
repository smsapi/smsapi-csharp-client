using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var list = features.Sendernames()
    .List()
    .ToIterator();

foreach (var sendername in list)
{
    Console.WriteLine(sendername.Sender);
}
