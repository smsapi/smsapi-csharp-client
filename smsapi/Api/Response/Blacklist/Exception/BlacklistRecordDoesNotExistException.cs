using smsapi.Api.Response.REST.Exception;

namespace SMSApi.Api.Response.Blacklist.Exception;

public class BlacklistRecordDoesNotExistException : NotFoundException
{
    public BlacklistRecordDoesNotExistException() : base("record does not exist")
    {
    }
}
