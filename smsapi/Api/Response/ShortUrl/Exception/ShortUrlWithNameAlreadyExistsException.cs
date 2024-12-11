namespace SMSApi.Api.Response.ShortUrl.Exception;

public class ShortUrlWithNameAlreadyExistsException : ClientException
{
    public ShortUrlWithNameAlreadyExistsException() : base("Short url with name already exists", 409)
    {
    }
}
