using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action;

public sealed class SMSDelete : Action<Countable>
{
    private string[] _ids;

    public SMSDelete(params string[] id)
    {
        _ids = id;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    [Obsolete($"Use {nameof(SMSDelete)} instead")]
    public SMSDelete Id(string id)
    {
        _ids = new[] { id };

        return this;
    }

    [Obsolete($"Use {nameof(SMSDelete)} instead")]
    public SMSDelete Id(string[] ids)
    {
        _ids = ids;

        return this;
    }

    protected override string Uri()
    {
        return "sms.do";
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        return (new NameValueCollection
        {
            { "sch_del", string.Join(",", _ids.ToHashSet()) }
        }, default);
    }
}
