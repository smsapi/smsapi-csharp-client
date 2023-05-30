using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SMSApi.Api;

namespace smsapiTests.Integration;

public abstract class IntegrationTestBase
{
    protected static string CurrentHost;
    
    protected void RunTestServer()
    {
        CurrentHost = FreeHost();
        
        new WebHostBuilder()
            .UseKestrel()
            .UseStartup(typeof(Program))
            .UseUrls(CurrentHost)
            .Configure(app => app.UseMiddleware<RequestInterceptorMiddleware>())
            .Build()
            .Start();
    }

    protected static ProxyHTTP GetProxy()
    {
        return new ProxyHTTP(CurrentHost);
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

    public void Configure(IApplicationBuilder applicationBuilder)
    {
    }
}
