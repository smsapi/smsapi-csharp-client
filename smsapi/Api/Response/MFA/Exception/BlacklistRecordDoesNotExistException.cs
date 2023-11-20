namespace SMSApi.Api.Response.MFA.Exception;

public class BlacklistRecordDoesNotExistException : ClientException
{
    public BlacklistRecordDoesNotExistException() : base("record does not exist", 404)
    {
    }
}
