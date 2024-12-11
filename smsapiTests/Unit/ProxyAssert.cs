using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Unit;

public class ProxyAssert(SpyProxy proxy)
{
    public void AssertRequestMethod(RequestMethod requestMethod)
    {
        Assert.AreEqual(requestMethod, proxy.RequestMethod);
    }
    
    public void AssertUriEquals(string uri)
    {
        Assert.IsTrue(
            proxy.RequestedUri.Equals(uri), 
            $"expected: {uri}, got: {proxy.RequestedUri}"
            );
    }

    public void AssertNoParameters()
    {
        var parametersCount = proxy.Parameters.Count;
        
        Assert.IsTrue(parametersCount == 0, $"Parameters expected to be empty, {parametersCount} found");
    }

    public void AssertParametersCount(int expectedCount)
    {
        Assert.AreEqual(
            expectedCount,
            proxy.Parameters.Count
        );
    }
    
    public void AssertParametersContain(string name, string value)
    {
        var expectedParameter = new KeyValuePair<string, dynamic?>(name, value);

        Assert.IsTrue(
            proxy.Parameters.Contains(value: expectedParameter),
            $"Expected {value}, actual value: {proxy.Parameters[name]}"
        );
    }

    public void AssertFileAttached(Stream file)
    {
        Assert.IsTrue(
            proxy.Files.Contains(value: file),
            "Not attached file found"
        );
    }
    
    public void AssertParametersContain(string name, dynamic value)
    {
        Assert.IsTrue(
            proxy.Parameters.ContainsKey(name),
            $"Key not found in sent parameters: {name}"
        );
        Assert.AreEqual(
            JsonSerializer.Serialize(value),
            JsonSerializer.Serialize(proxy.Parameters[name])
        );
    }
    
    public void AssertParametersDoesNotContain(string name)
    {
        Assert.IsFalse(
            proxy.Parameters.ContainsKey(name),
            $"Key not expected {name}"
        );
    }
}
