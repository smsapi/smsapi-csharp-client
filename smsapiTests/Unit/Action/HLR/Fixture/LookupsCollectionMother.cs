using System;
using System.Collections.Generic;
using SMSApi.Api.Response.Common.Telephony;
using SMSApi.Api.Response.HLR;
using smsapiTests.Unit.Fixture;

namespace smsapiTests.Unit.Action.HLR.Fixture;

public static class LookupsCollectionMother
{
    public static Dictionary<string, dynamic> EmptyCollection = CollectionMother.Empty();

    public static Dictionary<string, dynamic> Lookups(
        string id,
        string phoneNumber,
        string @interface,
        Country? country,
        Network? network,
        LookupCost cost,
        Ported? ported,
        uint? errorCode,
        DateTime sentAt
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
                        { "phone_number", phoneNumber },
                        {
                            "country", country != null
                                ? new Dictionary<string, dynamic?>
                                {
                                    { "name", country.Value.Name },
                                    { "mcc", country.Value.MCC }
                                }
                                : null
                        },
                        {
                            "network", network != null
                                ? new Dictionary<string, dynamic?>
                                {
                                    { "name", network.Value.Name },
                                    { "mnc", network.Value.MNC }
                                }
                                : null
                        },
                        {
                            "cost", cost
                        },
                        {
                            "interface", @interface
                        },
                        {
                            "sent_at", sentAt
                        },
                        {
                            "ported", ported
                        },
                        {
                            "error_code", errorCode
                        }
                    }
                }
            },
            { "size", 1 }
        };
    }
}