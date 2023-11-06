using System.Collections.Generic;

namespace SMSApi.Api.Response.ResponseResolver
{
    public interface IResponseCodeAwareResolver: IErrorResponse
    {
        public Dictionary<int, string> GetCodeErrorMap();
    }
}
