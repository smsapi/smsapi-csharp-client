using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action;

namespace smsapiTests.Unit.Action.VMS;

[TestClass]
public class VMSSendTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public VMSSendTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void send_with_file_uses_form_content_and_attaches_file()
    {
        var file = new MemoryStream(Encoding.UTF8.GetBytes("audio content"));

        VMSSend().SetTo("48500100100").SetFile(file).Execute();

        _proxyAssert.AssertContentType(ActionContentType.FormWww);
        _proxyAssert.AssertFileAttached("file", new MemoryStream(Encoding.UTF8.GetBytes("audio content")));
        _proxyAssert.AssertParametersContain("to", "48500100100");
    }

    [TestMethod]
    public void send_with_file_url()
    {
        VMSSend().SetTo("48500100100").SetFileUrl("https://example.com/audio.wav").Execute();

        _proxyAssert.AssertParametersContain("file", "https://example.com/audio.wav");
    }

    [TestMethod]
    public void send_to_group()
    {
        VMSSend().SetGroup("group name").SetTTS("tts content").Execute();

        _proxyAssert.AssertParametersContain("group", "group name");
        _proxyAssert.AssertParametersContain("tts", "tts content");
        _proxyAssert.AssertParametersDoesNotContain("to");
    }

    [TestMethod]
    public void recipient_is_required()
    {
        Assert.ThrowsException<ArgumentException>(() => VMSSend().SetTTS("tts content").Execute());
    }

    [TestMethod]
    public void tts_and_file_url_cannot_be_used_together()
    {
        Assert.ThrowsException<ArgumentException>(() =>
            VMSSend().SetTo("48500100100").SetTTS("tts content").SetFileUrl("https://example.com/audio.wav").Execute()
        );
    }

    private VMSSend VMSSend()
    {
        var action = new VMSSend();
        action.Proxy(_spyProxy);

        return action;
    }
}
