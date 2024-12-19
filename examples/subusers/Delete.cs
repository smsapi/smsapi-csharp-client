using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

string subuserId = "593FAFB33361354EAF84E7A2";

try
{
    features.Subusers()
        .Delete(subuserId)
        .Execute();

    //subuser is deleted at this point
}
catch (NotFoundException)
{
}
