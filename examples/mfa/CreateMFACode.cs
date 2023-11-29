using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;
using SMSApi.Api.Response.MFA.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string phoneNumber = "48100100100";

try
{
    var mfaCode = features.MFA()
        .CreateMfaCode(phoneNumber)
        .FromSendername("SMSAPI")                //Send code from sendername (optional)
        .WithContent("Your code is [%code%]")    //Send code with custom content (optional)
        .Execute();
    
    Console.WriteLine(mfaCode.Id);
    Console.WriteLine(mfaCode.Code);
    Console.WriteLine(mfaCode.PhoneNumber);
    Console.WriteLine(mfaCode.From);
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
    {
        Console.WriteLine(validationErrorsError.Message);
    }
}
catch (TooManyRequestsException ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
catch (ClientException ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
