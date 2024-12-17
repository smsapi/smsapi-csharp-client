using SMSApi.Api;
using SMSApi.Api.Action;
using SMSApi.Api.Response;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recipient = "48322320667";
const string message = "message";

var sendResult = features.SMS()
    .ActionSend(recipient, message)
    .WithFallback(SMSSend.SmsFallbacks.Vms)
    .Execute();

Console.WriteLine($"SMS sent count: {sendResult.Count}"); //no sms sent
Console.WriteLine($"Fallback sent count: {sendResult.Fallbacks?.Count ?? 0}"); //fallbacks count

foreach (var sendResultFallback in sendResult.Fallbacks ?? new())
{
    Console.WriteLine($"Fallback type: {sendResultFallback.Key}"); //fallback type
    Console.WriteLine($"Fallbacks of type sent: {sendResultFallback.Value.Count}"); //fallbacks count

    sendResultFallback.Value.List.ForEach(fallback =>
    {
        Console.WriteLine($"Fallback id: {fallback.Id}");
        Console.WriteLine(fallback.Idx);
        Console.WriteLine(fallback.Points);
        Console.WriteLine(fallback.DateSent);
    });
}
