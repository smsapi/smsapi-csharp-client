using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests;

[TestClass]
public class ConfigurationTest
{
    [TestMethod]
    public void VerifyConfiguration()
    {
        ExeConfigurationFileMap map = new();
        map.ExeConfigFilename = "testhost.dll.config";
        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        
        var token = ConfigurationManager.AppSettings["oauthToken"];
        Assert.IsNotNull(token);
        Assert.AreNotEqual("", token);

        var validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        Assert.IsNotNull(validTestNumber);
        Assert.AreNotEqual("", validTestNumber);

        ProxyAddress proxy;
        Assert.IsTrue(Enum.TryParse(ConfigurationManager.AppSettings["addressType"], out proxy));
    }
}
 
