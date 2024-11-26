using System.Collections.Specialized;
using SMSApi.Api.Response.OptOut;

namespace SMSApi.Api.Action.OptOut;

public sealed class ChangeOptOutSettings : Action<OptOutSettings>
{
    private string? _brandName;
    
    protected override RequestMethod Method => RequestMethod.PUT;
    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return "opt_outs/settings";
    }

    public ChangeOptOutSettings ChangeBrandName(string brandName)
    {
        _brandName = brandName;

        return this;
    }

    protected override NameValueCollection Values()
    {
        var values = new NameValueCollection();
        
        _brandName?.Let(newName => values.Add("brand", newName));

        return values;
    }
}
