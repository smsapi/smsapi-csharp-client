using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string linkId = "5";

var linkClicks = features.ShortUrl()
    .ListClicks()
    .ListFrom(DateTime.MinValue) //optional
    .ListTo(DateTime.MaxValue) //optional
    .Execute();

linkClicks.Collection.ForEach(click =>
{
    Console.WriteLine($"Short link: {click.ShortUrl}");
    Console.WriteLine($"Short link name: {click.Name}");
    Console.WriteLine($"Browser: {click.Browser}");
    Console.WriteLine($"Device: {click.Device}");
    Console.WriteLine($"Operating system: {click.Os}");
    Console.WriteLine($"Phone number: {click.PhoneNumber}");
    Console.WriteLine($"Hit date: {click.DateHit}");
});
