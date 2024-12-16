using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var links = features.ShortUrl()
    .List()
    .Execute();

links.Collection.ForEach(link =>
{
    Console.WriteLine(link.Id);
    Console.WriteLine(link.Description);
    Console.WriteLine(link.ExpireAt);
    Console.WriteLine(link.FileName);
    Console.WriteLine(link.Hits);
    Console.WriteLine(link.UniqueHits);
    Console.WriteLine(link.Name);
    Console.WriteLine(link.Url);
    Console.WriteLine(link.Type);
    Console.WriteLine(link.ShortUrl);
});
