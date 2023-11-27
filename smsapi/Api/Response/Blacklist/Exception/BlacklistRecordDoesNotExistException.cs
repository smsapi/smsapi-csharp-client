namespace SMSApi.Api.Response.Blacklist.Exception;

public class BlacklistRecordDoesNotExistException : ClientException
{
    public BlacklistRecordDoesNotExistException() : base("record does not exist", 404)
    {
    }
}
