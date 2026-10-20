using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recipient = "4850010010";

const string smil = """
    <smil>
        <head>
            <layout>
                <root-layout height="600" width="425"/>
                <region id="Image" top="0" left="0" height="100%" width="100%" fit="meet"/>
            </layout>
        </head>
        <body>
            <par dur="5000ms">
                <img src="https://www.smsapi.pl/logo.png" region="Image"></img>
            </par>
        </body>
    </smil>
    """;

var sendResult = features.MMS()
    .ActionSend(recipient)
    .SetSubject("subject")
    .SetSmil(smil)
    .Execute();

Console.WriteLine($"MMS sent count: {sendResult.Count}");

sendResult.List.ForEach(mms =>
{
    Console.WriteLine($"ID: {mms.ID}");
    Console.WriteLine($"Number: {mms.Number}");
    Console.WriteLine($"Status: {mms.Status}");
    Console.WriteLine($"Points: {mms.Points}");
});
