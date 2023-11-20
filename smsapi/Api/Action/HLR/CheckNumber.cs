using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    [Obsolete]
    public class HLRCheckNumber : Action<CheckNumber>
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
