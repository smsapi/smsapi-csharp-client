using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var result = features.Prices()
    .GetPrices()
    .Execute();

result.Collection
    .ToList()
    .ForEach(p =>
    {
        Console.WriteLine($"Price for {p.Country.Name} / {p.Network.Name} is {p.Price.Amount} {p.Price.Currency}");
    });
