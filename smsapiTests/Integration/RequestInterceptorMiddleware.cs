using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace smsapiTests.Integration;

public class RequestInterceptorMiddleware
{
    private readonly RequestDelegate _next;

    public RequestInterceptorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        RequestStorage.Method = context.Request.Method;
        RequestStorage.AuthorizationHeader = context.Request.Headers.Authorization;
        RequestStorage.UserAgentHeader = context.Request.Headers.UserAgent;
        RequestStorage.Path = $"{context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path.Value}";

        await _next(context);
    }
}
