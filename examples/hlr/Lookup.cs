using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

const string phoneNumberToCheck = "48500100100";

try
{
    features.HLR()
        .Lookup(phoneNumberToCheck)
        .Execute();
    
    //lookup successfully requested
}
catch (ValidationException ex)
{
    foreach (var validationErrorsError in ex.ValidationErrors.Errors)
    {
        Console.WriteLine(validationErrorsError.Message);
    }
}
