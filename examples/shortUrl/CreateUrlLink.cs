using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;
using smsapi.Api.Response.REST.Exception;
using SMSApi.Api.Response.ShortUrl.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string name = "abc";
const string url = "http://example.com";

try
{
    var link = features.ShortUrl()
        .Create(name, url)
        .WithDescription("my fancy link") //Set description (optional)
        .WithExpiration(1, CreateShortUrl.ShortUrlExpirationUnit.Hours) //Set expiration period (optional)
        .Execute();

    Console.WriteLine(link.Id);
}
catch (ShortUrlWithNameAlreadyExistsException)
{
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
