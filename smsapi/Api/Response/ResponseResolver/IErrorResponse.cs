namespace SMSApi.Api.Response.ResponseResolver
{
    public interface IErrorResponse
    {
        public bool IsError();
        public string GetErrorMessage();
    }
}
