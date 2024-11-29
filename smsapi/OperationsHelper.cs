using System;

namespace SMSApi.Api;

internal static class OperationsHelper
{
    public static void Let<T>(this T value, Action<T> action) where T : class
    {
        action(value);
    }
}
