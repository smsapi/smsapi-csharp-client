using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string linkId = "5";

try
{
    var updatedLink = features.ShortUrl()
        .UpdateShortUrl(linkId)
        .ChangeDescription("new description") //optional
        .ChangeName("new name") //optional
        .ChangeUrl("htp://example.com") //optional
        .Execute();

    Console.WriteLine(updatedLink.Id);
    Console.WriteLine(updatedLink.Description);
    Console.WriteLine(updatedLink.ExpireAt);
    Console.WriteLine(updatedLink.FileName);
    Console.WriteLine(updatedLink.Hits);
    Console.WriteLine(updatedLink.UniqueHits);
    Console.WriteLine(updatedLink.Name);
    Console.WriteLine(updatedLink.Url);
    Console.WriteLine(updatedLink.Type);
    Console.WriteLine(updatedLink.ShortUrl);
}
catch (NotFoundException)
{
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
