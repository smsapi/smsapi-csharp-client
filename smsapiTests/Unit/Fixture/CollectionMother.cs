using System.Collections.Generic;

namespace smsapiTests.Unit.Fixture;

public static class CollectionMother
{
    public static Dictionary<string, dynamic> Empty()
    {
        return new Dictionary<string, dynamic>
        {
            { "collection", new List<dynamic>() },
            { "size", 0 }
        };
    }

    public static Dictionary<string, dynamic> WithItems(params Dictionary<string, dynamic>[] items)
    {
        return new Dictionary<string, dynamic>
        {
            {
                "collection", items
            },
            {
                "size", items.Length
            }
        };
    }
}
