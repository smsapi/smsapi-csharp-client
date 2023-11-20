using System.Collections.Specialized;
using SMSApi.Api.Response.HLR;

namespace SMSApi.Api.Action;

public sealed class Lookup : Action<SingleCheckResult>
{
    private readonly string _numberToCheck;

    public Lookup(string numberToCheck)
    {
        _numberToCheck = numberToCheck;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    protected override string Uri() => "hlr/lookups";

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override NameValueCollection Values()
    {
        return new NameValueCollection { { "phone_number", _numberToCheck } };
    }
}
