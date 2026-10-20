using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var ids = new[] { "<sms_id>", "<another_sms_id>" };

var result = features.SMS()
    .ActionGet(ids)
    .Execute();

result.List.ForEach(sms =>
{
    Console.WriteLine($"ID: {sms.ID}");
    Console.WriteLine($"Number: {sms.Number}");
    Console.WriteLine($"Status: {sms.Status}");
    Console.WriteLine($"Points: {sms.Points}");
    Console.WriteLine($"Is final: {sms.isFinal()}");
});
