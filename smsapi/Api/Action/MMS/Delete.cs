using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class MMSDelete : BaseDeprecated
    {
        public MMSDelete() : base()
        {
        }

        protected string[] _Id;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("sch_del", string.Join("|", _Id));

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.List Execute()
        {
            Validate();

            Stream data = proxy.Execute("mms.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.List));
            SMSApi.Api.Response.List response = (SMSApi.Api.Response.List)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        public MMSDelete Id(string id)
        {
            this._Id = new string[] { id };
            return this;
        }

        public MMSDelete Id(string[] ids)
        {
            this._Id = ids;
            return this;
        }
    }
}
