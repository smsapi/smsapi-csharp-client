using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

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
        RequestStorage.RawPath = context.Request.GetDisplayUrl();
        RequestStorage.FormParameters = context.Request.Form.ToDictionary(k => k.Key, v => v.Value.ToString());

        await _next(context);
    }
}
