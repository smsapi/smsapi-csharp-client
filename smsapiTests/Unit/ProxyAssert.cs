using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Unit;

public class ProxyAssert
{
    private readonly SpyProxy _proxy;

    public ProxyAssert(SpyProxy proxy)
    {
        _proxy = proxy;
    }

    public void AssertUriEquals(string uri)
    {
        Assert.IsTrue(_proxy.RequestedUri.Equals(uri));
    }
    
    public void AssertParametersContain(string name, string value)
    {
        var expectedParameter = new KeyValuePair<string, string>(name, value);

        Assert.IsTrue(
            _proxy.Parameters.Contains(value: expectedParameter),
            $"Expected {value}, actual value: {_proxy.Parameters[name]}"
        );
    }
    
    public void AssertParametersDoesNotContain(string name)
    {
        Assert.IsFalse(
            _proxy.Parameters.ContainsKey(name),
            $"Key not expected {name}"
        );
    }
}
