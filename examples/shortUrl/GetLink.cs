using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string linkId = "5";

try
{
    var link = features.ShortUrl()
        .GetShortUrl(linkId)
        .Execute();

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
}
catch (NotFoundException)
{
}
