using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recipient = "4850010010";
var file = new FileInfo("<path_to_wav_file>");

var sendResult = features.VMS()
    .ActionSend(recipient)
    .SetFile(file) //Audio file (wav) sent with the request
    //.SetFileUrl("https://example.com/message.wav") //Alternatively: audio file fetched by SMSAPI from URL
    .Execute();

Console.WriteLine($"VMS sent count: {sendResult.Count}");

sendResult.List.ForEach(vms =>
{
    Console.WriteLine($"ID: {vms.ID}");
    Console.WriteLine($"Status: {vms.Status}");
});
