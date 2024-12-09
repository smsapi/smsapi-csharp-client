using System.Collections.Generic;

namespace smsapiTests.Unit.SMS.Fixture;

public static class SmsSendResponseMother
{
    public static Dictionary<string, dynamic> VmsFallback(
        string id,
        string idx,
        long dateSent,
        double points
    )
    {
        return new Dictionary<string, dynamic>
        {
            { "count", 0 },
            { "list", new List<dynamic>() },
            {
                "fallbacks", new Dictionary<string, dynamic>
                {
                    {
                        "vms", new Dictionary<string, dynamic>
                        {
                            { "count", 1 },
                            {
                                "list", new List<dynamic>
                                {
                                    new Dictionary<string, dynamic>
                                    {
                                        { "id", id },
                                        { "idx", idx },
                                        { "date_sent", dateSent },
                                        { "points", points }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
