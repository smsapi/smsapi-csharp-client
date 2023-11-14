namespace SMSApi.Api.Response.MFA.Exception;

public class ExpiredVerificationCodeException : ClientException
{
    public ExpiredVerificationCodeException() : base("Verification code has expired", 408)
    {
    }
}
