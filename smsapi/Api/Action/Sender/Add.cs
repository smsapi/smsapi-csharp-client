using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class SenderAdd : BaseDeprecated
    {
        private string Name;

        public SenderAdd SetName(string name)
        {
            Name = name;
            return this;
        }

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("add", string.Join("|", Name));

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.List Execute()
        {
            Validate();

            Stream data = proxy.Execute("sender.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.List));
            SMSApi.Api.Response.List response = (SMSApi.Api.Response.List)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }
    }
}
