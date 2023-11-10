using SMSApi.Api;
using SMSApi.Api.Response.Deserialization;
using smsapi.Api.Response.Deserialization.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string phoneNumber = "48100100100";

try
{
    var mfaCode = features.MFA()
        .CreateMfaCode(phoneNumber)
        .AsFast()                                //Send code in fast message (optional)
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
    var errors = ex.ValidationErrors;
}
catch (TooManyRequestsErrorResolver.TooManyRequestsException)
{
}
catch (ClientException ex)
{
}
