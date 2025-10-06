using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response.Sendernames;

namespace SMSApi.Api.Action.Sendernames;

public sealed class CreateSendername : Action<Sendername>
{
    private readonly string _sender;

    public CreateSendername(string sender)
    {
        _sender = sender;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override ActionContentType ContentType => ActionContentType.Json;

    protected override string Uri()
    {
        return "sms/sendernames";
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        return (
            new NameValueCollection(),
            new HashSet<KeyValuePair<string, dynamic?>> { KeyValuePair.Create<string, dynamic>("sender", _sender) }
            );
    }
}
