using System.Collections.Generic;
using SMSApi.Api.Response.Subusers;
using smsapiTests.Unit.Fixture;

namespace smsapiTests.Unit.Action.Subusers.Fixture;

public static class SubuersCollectionMother
{
    public static Dictionary<string, dynamic> Collection(
        string id,
        string username,
        bool active,
        string description,
        UserPoints userPoints
    )
    {
        return CollectionMother.WithItems(new Dictionary<string, dynamic>
        {
            { "id", id },
            { "username", username },
            { "active", active },
            { "description", description },
            {
                "points", userPoints
            }
        });
    }
}
