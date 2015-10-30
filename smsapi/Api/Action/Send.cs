using System.IO;

namespace SMSApi.Api.Action
{
    public abstract class Send : BaseSimple<Response.Status>
    {
        protected Send() : base() {}

        protected string[] To;
        protected string Group;
        protected string DateSent;
        protected string[] Idx;
        protected bool IdxCheck = false;
        protected string Partner;
        protected bool Test = false;
    }
}
