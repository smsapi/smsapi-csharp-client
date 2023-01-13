using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class HLRCheckNumber : Base<CheckNumber>
    {
        private string number;

        protected override RequestMethod Method => RequestMethod.POST;

        public HLRCheckNumber SetNumber(string number)
        {
            this.number = number;
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
                { "number", this.number }
            };
        }
    }
}
