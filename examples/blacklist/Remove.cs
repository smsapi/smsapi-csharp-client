using SMSApi.Api;
using smsapi.Api.Response.REST.Exception;

var client = new ClientOAuth("token");
var features = new Features(client);

const string recordId = "655B26893332330011B0B297";

try
{
    features.Blacklist()
        .Remove(recordId)
        .Execute();
    
    //record is deleted at this point
}
catch (BlacklistRecordDoesNotExistException exception)
{
}
