using SMSApi.Api;
using SMSApi.Api.Response.MFA;
using smsapi.Api.Response.REST.Exception;
using SMSApi.Api.Response.MFA.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string phoneNumber = "48100100100";
const string code = "123456";

try
{
    features.MFA()
        .VerifyMfaCode(phoneNumber, code)
        .Execute();
    
    //code is valid at this point
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
    {
        Console.WriteLine(validationErrorsError.Message);
    }
}
catch (InvalidVerificationCodeException)
{
}
catch (ExpiredVerificationCodeException)
{
}
