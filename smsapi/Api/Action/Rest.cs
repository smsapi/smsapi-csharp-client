using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SMSApi.Api.Action
{
	public abstract class Rest<T> : BaseSimple<T>
	{
		public Rest()
			: base()
		{
		}

		protected override string Uri()
		{
			string uri = Resource;
			if (Method == "GET")
			{
				if (Parameters.Count > 0) uri += "?" + Parameters.ToString();
			}
			return uri;
		}

		protected override NameValueCollection Values()
		{
			NameValueCollection collection = new NameValueCollection();
			if (Method == "POST" || Method == "PUT")
			{
				collection = Parameters;
			}
			return collection;
		}

		protected abstract string Resource { get; }

		protected virtual NameValueCollection Parameters { get { return HttpUtility.ParseQueryString(string.Empty); } }
	}
}
