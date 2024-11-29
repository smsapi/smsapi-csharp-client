using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var profile = features.Profile()
    .GetProfile()
    .Execute();

Console.WriteLine($"Name: {profile.Name}");
Console.WriteLine($"Username: {profile.Username}");
Console.WriteLine($"Email: {profile.Email}");
Console.WriteLine($"Phone number: {profile.PhoneNumber}");
Console.WriteLine($"User Type: {profile.UserType}");
Console.WriteLine($"Points: {profile.Points}");
Console.WriteLine($"Payment type: {profile.PaymentType}");
