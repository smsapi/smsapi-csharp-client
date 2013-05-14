using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class SenderSetDefault : BaseDeprecated
    {
        private string name;

        public SenderSetDefault Name(string name)
        {
            this.name = name;
            return this;
        }

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("default", this.name);

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.Group Execute()
        {
            Validate();

            Stream data = proxy.Execute("sender.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.Group));
            SMSApi.Api.Response.Group response = (SMSApi.Api.Response.Group)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }
    }
}
