using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response.Subusers;

namespace SMSApi.Api.Action.Subusers.Creation;

public sealed class CreateSubuser : Action<SubuserDetails>
{
    private readonly SubuserCredentials _credentials;

    private bool _active;
    private string? _desription;

    private SubuserPoints? _points;

    public CreateSubuser(SubuserCredentials credentials)
    {
        _credentials = credentials;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    protected override ActionContentType ContentType => ActionContentType.Json;

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return "subusers";
    }

    public CreateSubuser AsActive()
    {
        _active = true;

        return this;
    }

    public CreateSubuser WithDescription(string description)
    {
        _desription = description;

        return this;
    }

    public CreateSubuser WithPoints(SubuserPoints points)
    {
        _points = points;

        return this;
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        var values = new HashSet<KeyValuePair<string, dynamic?>>
        {
            {
                ("credentials", new Dictionary<string, string>
                {
                    { "username", _credentials.Username },
                    { "password", _credentials.Password },
                    { "api_password", _credentials.ApiPassword }
                }),
                ("active", _active)
            }
        };

        _desription?.Let(description => values.Add(("description", description)));

        _points?.Let(points =>
        {
            var pointsStructure = new Dictionary<string, double>();

            points.FromAccount?.Let(fromAccount => pointsStructure.Add("from_account", fromAccount));
            points.PerMonth?.Let(perMonth => pointsStructure.Add("per_month", perMonth));

            if (pointsStructure.Count > 0)
                values.Add(("points", pointsStructure));
        });

        return (new NameValueCollection(), values);
    }
}
