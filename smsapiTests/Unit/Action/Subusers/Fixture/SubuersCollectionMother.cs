using System.Collections.Generic;
using SMSApi.Api.Response.Subusers;

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
        return new Dictionary<string, dynamic>
        {
            {
                "collection", new List<dynamic>
                {
                    new Dictionary<string, dynamic>
                    {
                        { "id", id },
                        { "username", username },
                        { "active", active },
                        { "description", description },
                        {
                            "points", userPoints
                        }
                    }
                }
            },
            { "size", 1 }
        };
    }
}
