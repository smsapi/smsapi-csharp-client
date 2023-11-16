using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var result = features.Blacklist()
    .List()
    .Execute();

result.Collection.ForEach(record =>
    {
        Console.WriteLine($"ID: {record.Id}");
        Console.WriteLine($"Phone number: {record.PhoneNumber}");
        Console.WriteLine($"Created at: {record.DateCreated}");
        Console.WriteLine($"Expiring at: {record.DateExpired}");
    }
);
