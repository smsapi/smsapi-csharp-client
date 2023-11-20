using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var result = features.HLR()
    .ListLookups()
    .Execute();
    
result.Collection.ForEach(r =>
{
    Console.WriteLine($"ID: {r.Id}");
    Console.WriteLine($"Phone number: {r.PhoneNumber}");
    Console.WriteLine($"Interface: {r.Interface}");
    Console.WriteLine($"Country name: {r.Country?.Name}");
    Console.WriteLine($"MCC: {r.Country?.MCC}");
    Console.WriteLine($"Network name: {r.Network?.Name}");
    Console.WriteLine($"MNC: {r.Network?.MNC}");
    Console.WriteLine($"Cost: {r.Cost.Points}");
    Console.WriteLine($"Sent at: {r.SentAt}");
    Console.WriteLine($"Error code: {r.ErrorCode}");
    
    if (r.Ported != null)
        foreach (var mcc in r.Ported.Value.PortedFrom)
        {
            Console.WriteLine(mcc.Mcc);
        }
});
