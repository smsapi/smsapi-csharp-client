using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

var subuserId = "593FAFB33361354EAF84E7A2";

try
{
    features.Subusers()
        .Edit(subuserId)
        .ChangeDescription("new description") //optional
        .ChangePassword("new password") //optional
        .ChangePoints(new SubuserPoints( //optional
            10, // optional
            10 //optional
        ))
        .Execute();
}
catch (NotFoundException)
{
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
        Console.WriteLine(validationErrorsError.Message);
}
