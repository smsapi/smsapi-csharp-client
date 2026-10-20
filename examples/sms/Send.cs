using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recipient = "4850010010";
const string message = "message";

try
{
    var sendResult = features.SMS()
        .ActionSend(recipient, message)
        .SetSender("Test") //Sender name (optional)
        .SetIDx("my-custom-id") //Custom message id (optional)
        .SetDateSent(DateTime.Now.AddHours(1)) //Schedule sending (optional)
        .Execute();

    Console.WriteLine($"SMS sent count: {sendResult.Count}");

    sendResult.List.ForEach(sms =>
    {
        Console.WriteLine($"ID: {sms.ID}");
        Console.WriteLine($"Number: {sms.Number}");
        Console.WriteLine($"Status: {sms.Status}");
        Console.WriteLine($"Points: {sms.Points}");
        Console.WriteLine($"IDx: {sms.IDx}");
    });
}
catch (ActionException ex)
{
    //Action error, e.g. invalid sender name
    Console.WriteLine($"{ex.Code}: {ex.Message}");
}
catch (ClientException ex)
{
    //Client error, e.g. invalid token, insufficient credits
    Console.WriteLine($"{ex.Code}: {ex.Message}");
}
