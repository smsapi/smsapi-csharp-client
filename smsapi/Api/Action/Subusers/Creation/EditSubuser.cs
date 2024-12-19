using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response.Subusers;

namespace SMSApi.Api.Action.Subusers.Creation;

public sealed class EditSubuser : Action<SubuserDetails>
{
    private readonly string _userId;

    private bool? _active;
    private string? _desription;
    private string? _password;
    private SubuserPoints? _points;

    public EditSubuser(string userId)
    {
        _userId = userId;
    }

    protected override RequestMethod Method => RequestMethod.PUT;

    protected override ActionContentType ContentType => ActionContentType.Json;

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return $"subusers/{_userId}";
    }

    public EditSubuser Activate()
    {
        _active = true;

        return this;
    }

    public EditSubuser Deactivate()
    {
        _active = false;

        return this;
    }

    public EditSubuser ChangeDescription(string description)
    {
        _desription = description;

        return this;
    }

    public EditSubuser ChangePoints(SubuserPoints points)
    {
        _points = points;

        return this;
    }

    public EditSubuser ChangePassword(string newPassword)
    {
        _password = newPassword;

        return this;
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        var values = new HashSet<KeyValuePair<string, dynamic?>>();

        _active?.Let(newStatus => values.Add(("active", newStatus)));

        _password?.Let(newPassword =>
        {
            values.Add(
                ("credentials", new Dictionary<string, string> { { "password", newPassword } })
                );
        });

        _desription?.Let(newDescription => values.Add(("description", newDescription)));

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
