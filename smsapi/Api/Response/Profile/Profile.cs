using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Profile;

public sealed class Profile : IResponseCodeAwareResolver
{
    public readonly string Name;

    public readonly string Username;

    public readonly string Email;

    public readonly string PhoneNumber;

    public readonly string UserType;

    public readonly double Points;

    public readonly string PaymentType;
}
