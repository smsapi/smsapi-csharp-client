using System;
using System.Web;

namespace SMSApi.Api.Action;

public static class ActionPaginationHelper
{
    public static string ToUriWithPagination(this UriBuilder uriBuilder, uint? limit, uint? offset)
    {
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            
        if (limit != null)
            query.Add("limit", limit.ToString());
            
        if (offset != null)
            query.Add("offset", offset.ToString());

        uriBuilder.Query = query.ToString();

        return uriBuilder.Path + uriBuilder.Query;
    }
}
