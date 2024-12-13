using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace SMSApi.Api;

internal static class OperationsHelper
{
    public static void Let<T>(this T value, Action<T> action)
    {
        action(value);
    }

    public static string GetEnumValue<T>(this T enumValue) where T : Enum
    {
        var type = enumValue.GetType();
        MemberInfo[] memInfo = type.GetMember(enumValue.ToString());

        if (memInfo.Length <= 0) return enumValue.ToString();
        var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
        if (attributes.Length > 0) return ((EnumMemberAttribute)attributes[0]).Value;

        return enumValue.ToString();
    }

    public static void Add(this ISet<KeyValuePair<string, dynamic?>> set, params (string key, dynamic? value)[] values)
    {
        foreach (var valueTuple in values)
        {
            set.Add(KeyValuePair.Create<string, dynamic?>(valueTuple.key, valueTuple.value));
        }
    }
}
