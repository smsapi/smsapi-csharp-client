using System.Collections.Specialized;
using System.Web;

namespace SMSApi.Api.Action
{
    public abstract class Rest<T> : BaseSimple<T>
    {
        protected virtual NameValueCollection Parameters => HttpUtility.ParseQueryString(string.Empty);

        protected abstract string Resource { get; }

        protected override string Uri()
        {
            string uri = Resource;
            if (RequestMethod.GET.Equals(Method))
            {
                if (Parameters.Count > 0)
                {
                    uri += "?" + Parameters;
                }
            }

            return uri;
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();
            if (RequestMethod.POST.Equals(Method) || RequestMethod.PUT.Equals(Method))
            {
                collection = Parameters;
            }

            return collection;
        }
    }
}
