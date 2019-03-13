using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupList : BaseSimple<Response.Groups>
    {
        protected override string Uri() => "phonebook.do";

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"list_groups", ""}
            };

            return collection;
        }
    }
}