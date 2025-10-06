using System;

namespace smsapiTests.Unit.Helper;

public static class RandomHelper
{
    public static bool NextBoolean(this Random random)
    {
        return random.Next() > int.MaxValue / 2;
    }
}
