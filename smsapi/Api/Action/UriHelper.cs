using System;

namespace SMSApi.Api.Action;

public static class UriHelper
{
    public static string ToPathWithQuery(this UriBuilder uriBuilder)
    {
        return uriBuilder.Path + uriBuilder.Query;
    }
}
