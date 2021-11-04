using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListFields : Rest<Fields>
    {
        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/fields";
    }
}
