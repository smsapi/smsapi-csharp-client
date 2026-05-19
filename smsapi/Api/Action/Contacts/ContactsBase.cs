namespace SMSApi.Api.Action
{
    public abstract class ContactsBase<T> : Base<T>
    {
        protected override bool IncludeJsonFormatParameter => false;
    }
}
