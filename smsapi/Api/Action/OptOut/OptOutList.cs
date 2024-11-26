using System.Collections.Specialized;
using SMSApi.Api.Response;
using OptOutModel = SMSApi.Api.Response.OptOut.OptOut;

namespace SMSApi.Api.Action.OptOut;

public sealed class OptOutList : Action<BasicCollection<OptOutModel>>, IPaginable
{
    private string? _phoneNumber;
    
    protected override RequestMethod Method => RequestMethod.GET;

    public uint? Limit { get; set; }
    public uint? Offset { get; set; }

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return "opt_outs";
    }

    public OptOutList FilterByPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;

        return this;
    }

    protected override NameValueCollection Values()
    {
        var values = new NameValueCollection();

        _phoneNumber?.Let(number => values.Add("phone_number", number));

        return values;
    }
}
