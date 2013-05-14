using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class HLRCheckNumber : BaseDeprecated
    {
        public HLRCheckNumber() { }

        protected string[] Numbers;

        public HLRCheckNumber SetNumber(string number)
        {
            this.Numbers = new string[] { number };
            return this;
        }

/*        public HLRCheckNumber SetNumber(string[] numbers)
        {
            this.Numbers = numbers;
            return this;
        }*/

        public SMSApi.Api.Response.CheckNumber Execute() 
        {
            Validate();

            Stream data = proxy.Execute("hlrsync.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.CheckNumber));
            SMSApi.Api.Response.CheckNumber response = (SMSApi.Api.Response.CheckNumber)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("number", string.Join(",", Numbers));

            return collection;
        }

        private void Validate()
        {
        }
    }   
}
