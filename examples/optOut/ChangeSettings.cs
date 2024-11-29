using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var optOutSettingsUpdateResult = features.OptOut()
    .ChangeSettings()
    .ChangeBrandName("new brand name")
    .Execute();

Console.WriteLine($"Brand: {optOutSettingsUpdateResult.Brand}");
