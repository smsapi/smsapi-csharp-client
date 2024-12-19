using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

string subuserId = "593FAFB33361354EAF84E7A2";

try
{
    features.Subusers()
        .Edit(subuserId)
        .Activate()
        .Execute();

    //subuser is activated at this point
}
catch (NotFoundException)
{
}
