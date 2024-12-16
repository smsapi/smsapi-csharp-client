using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string linkId = "5";

try
{
    features.ShortUrl()
        .DeleteShortUrl(linkId)
        .Execute();

    //link is deleted at this point
}
catch (NotFoundException)
{
}
