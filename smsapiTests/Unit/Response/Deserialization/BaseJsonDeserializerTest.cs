using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SMSApi.Api;
using SMSApi.Api.Response.Deserialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace smsapiTests.Unit.Response.Deserialization;

[TestClass]
public class BaseJsonDeserializerTest
{
    private readonly BaseJsonDeserializer _baseJsonDeserializer = new();

    [TestMethod]
    public void deserialize_public_field()
    {
        var json = new Dictionary<string, string>
        {
            { "Field", "abc" }
        };

        var result = Deserialize<PublicFields>(json);
        Assert.AreEqual("abc", result.Field);
    }

    [TestMethod]
    public void deserialize_public_readonly_field()
    {
        var json = new Dictionary<string, string>
        {
            { "Field", "abc" }
        };

        var result = Deserialize<PublicReadonlyFields>(json);
        Assert.AreEqual("abc", result.Field);
    }

    [TestMethod]
    public void deserialize_public_field_with_public_setter()
    {
        var json = new Dictionary<string, string>
        {
            { "Field", "abc" }
        };

        var result = Deserialize<PublicFieldsWithPublicSet>(json);
        Assert.AreEqual("abc", result.Field);
    }

    [TestMethod]
    public void deserialize_public_field_with_public_private_setter()
    {
        var json = new Dictionary<string, string>
        {
            { "Field", "abc" }
        };

        var result = Deserialize<PublicFieldsWithPrivateSet>(json);
        Assert.AreEqual("abc", result.Field);
    }

    [TestMethod]
    public void deserialize_public_field_with_type_reference()
    {
        var json = new Dictionary<string, List<Dictionary<string, string>>>
        {
            { "Collection", new List<Dictionary<string, string>> { new() { { "Field", "nested" } } } }
        };

        var result = Deserialize<PublicNestedFields>(json);
        Assert.AreEqual(1, result.Collection.Count);
        Assert.AreEqual("nested", result.Collection.First().Field);
    }

    [TestMethod]
    public void deserialize_public_field_with_readonly_type_reference()
    {
        var json = new Dictionary<string, List<Dictionary<string, string>>>
        {
            { "Collection", new List<Dictionary<string, string>> { new() { { "Field", "nested" } } } }
        };

        var result = Deserialize<PublicNestedFieldsWithReadonlyField>(json);
        Assert.AreEqual(1, result.Collection.Count);
        Assert.AreEqual("nested", result.Collection.First().Field);
    }

    [TestMethod]
    public void deserialize_public_field_with_private_set_type_reference()
    {
        var json = new Dictionary<string, List<Dictionary<string, string>>>
        {
            { "Collection", new List<Dictionary<string, string>> { new() { { "Field", "nested" } } } }
        };

        var result = Deserialize<PublicNestedFieldsWithPrivateSet>(json);
        Assert.AreEqual(1, result.Collection.Count);
        Assert.AreEqual("nested", result.Collection.First().Field);
    }
    
    [TestMethod]
    public void deserialize_with_custom_name()
    {
        var json = new Dictionary<string, string>
        {
            { "another_name", "abc" }
        };

        var result = Deserialize<FieldWithAnotherName>(json);
        Assert.AreEqual("abc", result.Field);
    }
    
    [TestMethod]
    public void deserialize_readonly_record_struct()
    {
        var json = new Dictionary<string, string>
        {
            { "Field", "abc" }
        };

        var result = Deserialize<ReadonlyRecordStruct>(json);
        Assert.AreEqual("abc", result.Field);
    }

    private T Deserialize<T>(dynamic content)
    {
        var stream = new MemoryStream();
        JsonSerializer.Serialize(stream, content);
        stream.Seek(0, SeekOrigin.Begin);

        var streamTask = Task.FromResult<Stream>(stream);
        var responseEntity = new HttpResponseEntity(streamTask, HttpStatusCode.OK);

        return _baseJsonDeserializer.Deserialize<T>(responseEntity).Result;
    }

    private class PublicFields
    {
        public string Field;
    }
    
    private class FieldWithAnotherName
    {
        [JsonProperty("another_name")]
        public string Field;
    }

    private class PublicReadonlyFields
    {
        public readonly string Field;
    }

    private class PublicFieldsWithPublicSet
    {
        public string Field { get; set; }
    }

    private class PublicFieldsWithPrivateSet
    {
        public string Field { get; private set; }
    }

    private class PublicNestedFields
    {
        public List<PublicFields> Collection;
    }

    private class PublicNestedFieldsWithReadonlyField
    {
        public readonly ICollection<PublicReadonlyFields> Collection = new List<PublicReadonlyFields>();
    }

    private class PublicNestedFieldsWithPrivateSet
    {
        public readonly ICollection<PublicFieldsWithPrivateSet> Collection = new List<PublicFieldsWithPrivateSet>();
    }

    private readonly record struct ReadonlyRecordStruct
    {
        public readonly string Field;
    }
}
