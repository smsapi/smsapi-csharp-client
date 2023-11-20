using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var result = features.Subusers()
    .List()
    .Execute();

result.Collection.ForEach(subuser =>
{
    Console.WriteLine($"ID: {subuser.Id}");
    Console.WriteLine($"Username: {subuser.Username}");
    Console.WriteLine($"Active: {subuser.Active}");
    Console.WriteLine($"Description: {subuser.Description}");
    Console.WriteLine($"Points shared with main user: {subuser.Points.FromAccount}");
    Console.WriteLine($"Monthly points' limit: {subuser.Points.PerMonth}");
});
