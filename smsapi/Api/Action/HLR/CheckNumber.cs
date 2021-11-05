using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class HLRCheckNumber : Base<CheckNumber>
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

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "format", "json" },
                { "number", string.Join(",", numbers) }
            };
        }
    }
}
