using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Integration;

public abstract class IntegrationTestBase
{
    private static string _currentHost;
    
    [TestInitialize]
    public void InitializeServer()
    {
        RunTestServer();
    }

    private static void RunTestServer()
    {
        _currentHost = FreeHost();
        
        new WebHostBuilder()
            .UseKestrel()
            .UseStartup(typeof(Program))
            .UseUrls(_currentHost)
            .Configure(app => app.UseMiddleware<RequestInterceptorMiddleware>())
            .Build()
            .Start();
    }

    protected static ProxyHTTP GetProxy()
    {
        return new ProxyHTTP(_currentHost);
    }

    private static string FreeHost()
    {
        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        
        return $"http://localhost:{port}";
    }
}

public class Program
{
    public Program(IConfiguration config)
    {
    }

    public static void Configure(IApplicationBuilder applicationBuilder)
    {
    }
}
