using System.Collections.Specialized;
using System.Web;

namespace SMSApi.Api.Action
{
    public abstract class Rest<T> : Base<T>
    {
        protected virtual NameValueCollection Parameters => HttpUtility.ParseQueryString(string.Empty);

        protected abstract string Resource { get; }

        protected override string Uri()
        {
            return Resource;
        }

        protected override NameValueCollection Values()
        {
            return Parameters;
        }
    }
}
