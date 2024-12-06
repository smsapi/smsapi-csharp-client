using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SMSApi.Api.Response.Deserialization;

internal class PrivateFieldsContractResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        var jsonProperties = base.CreateProperties(type, memberSerialization);

        var readonlyFields = GetPublicReadonlyFields(type);
        foreach (var field in readonlyFields)
            if (jsonProperties.All(p => p.PropertyName != field.Name))
                jsonProperties.Add(CreateProperty(field, memberSerialization));

        return jsonProperties;
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);

        switch (member)
        {
            case PropertyInfo propertyInfo:
            {
                if (HasPrivateSetter(propertyInfo)) jsonProperty.Writable = true;
                break;
            }
            case FieldInfo { IsInitOnly: true }:
                jsonProperty.Writable = true;
                break;
        }

        return jsonProperty;
    }

    private static IEnumerable<FieldInfo> GetPublicReadonlyFields(Type type)
    {
        return type.GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Where(field => field.IsInitOnly);
    }

    private static bool HasPrivateSetter(PropertyInfo propertyInfo)
    {
        var setMethod = propertyInfo.GetSetMethod(true);

        return setMethod != null && !setMethod.IsPublic;
    }
}
