using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var listSendernames = (uint collectionLimit, uint collectionOffset) =>
{
    var list = features.Sendernames().List();

    list.Limit = collectionLimit;
    list.Offset = collectionOffset;

    return list.Execute();
};

const uint limit = 25;
uint offset = 0;
bool hasMoreItems;

do
{
    var sendernames = listSendernames(limit, offset);

    sendernames.Collection.ForEach(sendername =>
    {
        Console.WriteLine($"Sender: {sendername.Sender}");
    });

    hasMoreItems = sendernames.Size > limit + offset;
    offset += limit;
} while (hasMoreItems);
