using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Unit;

public class ProxyAssert(SpyProxy proxy)
{
    public void AssertUriEquals(string uri)
    {
        Assert.IsTrue(proxy.RequestedUri.Equals(uri));
    }

    public void AssertNoParameters()
    {
        var parametersCount = proxy.Parameters.Count;
        
        Assert.IsTrue(parametersCount == 0, $"Parameters expected to be empty, {parametersCount} found");
    }
    
    public void AssertParametersContain(string name, string value)
    {
        var expectedParameter = new KeyValuePair<string, string>(name, value);

        Assert.IsTrue(
            proxy.Parameters.Contains(value: expectedParameter),
            $"Expected {value}, actual value: {proxy.Parameters[name]}"
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
