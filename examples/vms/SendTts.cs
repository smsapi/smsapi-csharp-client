using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recipient = "4850010010";

var sendResult = features.VMS()
    .ActionSend(recipient)
    .SetTTS("Hello, this is a text to speech message") //Text read by lector
    .SetTTSLector("ewa") //Lector name (optional)
    .SetTry(2) //Number of connection attempts (optional)
    .SetTryInterval(300) //Interval between attempts in seconds (optional)
    .Execute();

Console.WriteLine($"VMS sent count: {sendResult.Count}");

sendResult.List.ForEach(vms =>
{
    Console.WriteLine($"ID: {vms.ID}");
    Console.WriteLine($"Number: {vms.Number}");
    Console.WriteLine($"Status: {vms.Status}");
    Console.WriteLine($"Points: {vms.Points}");
});
