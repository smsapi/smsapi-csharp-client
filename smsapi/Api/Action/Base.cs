
namespace SMSApi.Api.Action
{
    public abstract class Base
    {
        protected Client client;
        protected Proxy proxy;

        public void Client(Client client)
        {
            this.client = client;
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
        }

        protected void ValidateResponse(SMSApi.Api.Response.Base obj)
        {
            if (obj.isError())
            {
                if (ThowApiException(obj.ErrorCode))
                {
                    throw new ApiException(obj.ErrorMessage, obj.ErrorCode);
                }
            }
        }

        private bool ThowApiException(int code)
        {
            if (code == 101) return true;
            if (code == 102) return true;
            if (code == 103) return true;
            if (code == 105) return true;
            if (code == 110) return true;
            if (code == 1000) return true;
            if (code == 1001) return true;

            return false;
        }
    }
}
