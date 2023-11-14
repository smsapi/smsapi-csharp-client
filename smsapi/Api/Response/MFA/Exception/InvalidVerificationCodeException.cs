namespace SMSApi.Api.Response.MFA.Exception;

public class InvalidVerificationCodeException : ClientException
{
    public InvalidVerificationCodeException() : base("Invalid verification code", 404)
    {
    }
}
