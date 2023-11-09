using System;
using SMSApi.Api.Action;
using SMSApi.Api.Response;

namespace smsapiTests.Unit;

public abstract class UnitTestBase<T> where T : SMSApi.Api.Action.Action<Status>
{
    protected readonly SpyProxy SpyProxy = new();

    protected virtual T CreateAction()
    {
        var action = Activator.CreateInstance<T>();
        action.Proxy(SpyProxy);

        return action;
    }

    protected void Execute(T action)
    {
        try
        {
            action.Execute();
        }
        catch (MissingMethodException)
        {
        }
    }
}
