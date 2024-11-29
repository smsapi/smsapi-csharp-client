using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var optOutSettings = features.OptOut()
    .Settings()
    .Execute();

Console.WriteLine($"Brand: {optOutSettings.Brand}");
