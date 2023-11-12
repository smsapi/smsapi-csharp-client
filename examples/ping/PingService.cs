using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var result = features.Ping()
    .PingService()
    .Execute();

Console.WriteLine(result.Authorized);

foreach (var unavailableService in result.UnavailableServices)
{
    Console.WriteLine($"Unavailable service: {unavailableService}");
}
