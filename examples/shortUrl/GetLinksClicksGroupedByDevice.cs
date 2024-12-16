using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

string[] linksIds = ["1", "5"];

var linkClicks = features.ShortUrl()
    .ListClicksGroupedByDeviceType(linksIds)
    .Execute();

linkClicks.Collection.ForEach(link =>
{
    Console.WriteLine($"Link id: {link.LinkId}");

    Console.WriteLine($"Clicks from Android: {link.Clicks.Android}");
    Console.WriteLine($"Clicks from Ios: {link.Clicks.Ios}");
    Console.WriteLine($"Clicks from Windows Phone: {link.Clicks.Wp}");
    Console.WriteLine($"Clicks from Unknown os: {link.Clicks.Other}");
    Console.WriteLine($"All clicks: {link.Clicks.Sum}");
});
