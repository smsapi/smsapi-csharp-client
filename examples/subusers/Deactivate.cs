using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

string subuserId = "593FAFB33361354EAF84E7A2";

try
{
    features.Subusers()
        .Edit(subuserId)
        .Deactivate()
        .Execute();

    //subuser is deactivated at this point
}
catch (NotFoundException)
{
}
