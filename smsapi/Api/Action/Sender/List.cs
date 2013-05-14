using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SMSApi.Api.Action
{
    public class SenderList : BaseDeprecated
    {
        public List<SMSApi.Api.Response.Sender> Execute()
        {
            Validate();

            Stream data = proxy.Execute("sender.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(List<SMSApi.Api.Response.Sender>));
            List<SMSApi.Api.Response.Sender> response = (List<SMSApi.Api.Response.Sender>)serializer.ReadObject(data);
            data.Close();

//            this.ValidateResponse(response);

            return response;
        }

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("list", "1");

            return collection;
        }

        private void Validate()
        {
        }
    }
}
