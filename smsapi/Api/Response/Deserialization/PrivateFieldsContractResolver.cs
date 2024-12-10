using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SMSApi.Api.Response.Deserialization;

internal class PrivateFieldsContractResolver : DefaultContractResolver
{
    public PrivateFieldsContractResolver()
    {
        NamingStrategy = new SnakeCaseNamingStrategy();
    }
    
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        var jsonProperties = base.CreateProperties(type, memberSerialization)
            .GroupBy(property => property.UnderlyingName, StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToHashSet();

        AddReadonlyMembers(type, memberSerialization, jsonProperties);

        return jsonProperties.ToList();
    }

    private void AddReadonlyMembers(Type type, MemberSerialization memberSerialization,
        HashSet<JsonProperty> jsonProperties)
    {
        IList<JsonProperty> readonlyProperties = new List<JsonProperty>();

        foreach (var field in GetPublicReadonlyFields(type))
            readonlyProperties.Add(CreateProperty(field, memberSerialization));

        foreach (var property in GetReadonlyProperties(type))
            readonlyProperties.Add(CreateProperty(property, memberSerialization));

        jsonProperties.RemoveWhere(property => readonlyProperties.Contains(property));
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);

        jsonProperty.Writable = member switch
        {
            PropertyInfo propertyInfo when HasPrivateSetter(propertyInfo) => true,
            FieldInfo { IsInitOnly: true } => true,
            _ => jsonProperty.Writable
        };

        return jsonProperty;
    }

    private static IEnumerable<FieldInfo> GetPublicReadonlyFields(Type type)
    {
        return type.GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Where(field => field.IsInitOnly);
    }

    private static IEnumerable<PropertyInfo> GetReadonlyProperties(Type type)
    {
        return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(IsInitOnly);
    }

    private static bool HasPrivateSetter(PropertyInfo propertyInfo)
    {
        var setMethod = propertyInfo.GetSetMethod(true);
        return setMethod != null && !setMethod.IsPublic;
    }

    private static bool IsInitOnly(PropertyInfo propertyInfo)
    {
        var setMethod = propertyInfo.GetSetMethod(true);
        return setMethod != null && !setMethod.IsPublic;
    }
}
