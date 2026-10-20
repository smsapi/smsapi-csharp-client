using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recipient = "4850010010";

var sendResult = features.SMS()
    .ActionSend(recipient)
    .SetTemplate("template name") //Template defined in SMSAPI panel
    .SetParam(0, "John") //Replaces [%1%] in the template
    .SetParam(1, "Doe") //Replaces [%2%] in the template
    .Execute();

Console.WriteLine($"SMS sent count: {sendResult.Count}");
