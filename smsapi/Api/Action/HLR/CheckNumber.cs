using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class HLRCheckNumber : BaseSimple<Response.CheckNumber>
    {
        protected override string Uri()
        {
            return "hlrsync.do";
        }

        protected string[] numbers;

        public HLRCheckNumber SetNumber(string number)
        {
            numbers = new[] {number};
            return this;
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
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"number", string.Join(",", numbers)}
            };

            return collection;
        }
    }
}