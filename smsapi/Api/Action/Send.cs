using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public abstract class Send : Action<Status>
    {
        protected string DateSent;
        protected string Group;
        protected string[] Idx;
        protected bool IdxCheck = false;
        protected string Partner;
        protected bool Test = false;

        protected string[] To;
    }
}
