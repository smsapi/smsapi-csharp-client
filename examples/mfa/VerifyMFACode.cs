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
    var errors = ex.ValidationErrors;
}
catch (InvalidVerificationCodeException)
{
}
catch (ExpiredVerificationCodeException)
{
}
