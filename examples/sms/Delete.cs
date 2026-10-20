using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

//Only scheduled (not yet sent) messages can be deleted
var ids = new[] { "<scheduled_sms_id>", "<another_scheduled_sms_id>" };

var result = features.SMS()
    .ActionDelete(ids)
    .Execute();

Console.WriteLine($"Deleted count: {result.Count}");
