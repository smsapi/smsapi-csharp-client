using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class HLRCheckNumber : BaseSimple<CheckNumber>
    {
        protected string[] numbers;

        public HLRCheckNumber SetNumber(string number)
        {
            numbers = new[] { number };
            return this;
        }

        protected override string Uri()
        {
            return "hlrsync.do";
        }

        /*
                public HLRCheckNumber SetNumber(string[] numbers)
                {
                    this.numbers = numbers;
                    return this;
                }
        */

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("number", string.Join(",", numbers));

            return collection;
        }
    }
}
