using System;
using RestSharp;

namespace SMSApi.Api
{
    public enum RequestMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public static class RequestMethodExtensions
    {
        public static Method ToMethod(this RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.DELETE:
                    return Method.Delete;

                case RequestMethod.GET:
                    return Method.Get;

                case RequestMethod.POST:
                    return Method.Post;

                case RequestMethod.PUT:
                    return Method.Put;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
