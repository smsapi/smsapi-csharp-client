using System.Collections.Generic;
using smsapiTests.Unit.Fixture;

namespace smsapiTests.Unit.Action.Profile.Prices.Fixture;

public static class PricesCollectionMother
{
    public static Dictionary<string, dynamic> EmptyCollection() => CollectionMother.Empty();

    public static Dictionary<string, dynamic> SinglePrice(
        float amount,
        string currency,
        string countryName,
        int mcc,
        string networkName,
        int mnc,
        string type
    )
    {
        return new Dictionary<string, dynamic>
        {
            {
                "collection", new List<dynamic>
                {
                    new Dictionary<string, dynamic>
                    {
                        { "type", type },
                        {
                            "price", new Dictionary<string, dynamic>
                            {
                                { "amount", amount },
                                { "currency", currency }
                            }
                        },
                        {
                            "country", new Dictionary<string, dynamic>
                            {
                                { "name", countryName },
                                { "mcc", mcc }
                            }
                        },
                        {
                            "network", new Dictionary<string, dynamic>
                            {
                                { "name", networkName },
                                { "mnc", mnc }
                            }
                        }
                    }
                }
            },
            { "size", 1 }
        };
    }
}
