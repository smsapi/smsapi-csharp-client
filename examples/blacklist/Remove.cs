using SMSApi.Api;
using SMSApi.Api.Response.Blacklist.Exception;

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
    System.Console.WriteLine(e.Message);
}
