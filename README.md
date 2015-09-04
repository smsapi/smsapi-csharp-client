csharp-client
===========

C# client which allows you to send SMS messages and manage your account in SMSAPI.com

Example of use:
```c#
try
{
	SMSApi.Api.Client client = new SMSApi.Api.Client("login");
	client.SetPasswordHash("md5password");

	var smsApi = new SMSApi.Api.SMSFactory(client);

	var result =
		smsApi.ActionSend()
			.SetText("test message")
			.SetTo("44xxxxxxxxxxxx")
			.SetSender("Info")
			.Execute();

	System.Console.WriteLine("Send: " + result.Count);

	string[] ids = new string[result.Count];

	for (int i = 0, l = 0; i < result.List.Count; i++)
	{
		if (!result.List[i].isError())
		{
			if (!result.List[i].isFinal())
			{
				ids[l] = result.List[i].ID;
				l++;
			}
		}
	}

	System.Console.WriteLine("Get:");
	result =
		smsApi.ActionGet()
			.Ids(ids)
			.Execute();

	foreach (var status in result.List)
	{
		System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
	}

	for (int i = 0, l = 0; i < result.List.Count; i++)
    {
        if (!result.List[i].isError())
        {
			var deleted = 
				smsApi.ActionDelete()
					.Id(result.List[i].ID)
					.Execute();
			System.Console.WriteLine("Deleted: " + deleted.Count);
		}
	}
}
catch (SMSApi.Api.ActionException e)
{
	/**
	 * Errors associated with the action (excluding errors 101,102,103,105,110,1000,1001,8,666,999,201)
	 * https://www.smsapi.com/resp
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.ClientException e)
{
	/**
	 * 101 Invalid authorization info. ATTENTION! API password ma be different than web panel password.
	 * 102 Invalid username or password.
	 * 103 Insufficient credits on Your account.
	 * 105 Wrong IP address (for IP filter turned on).
	 * 110 Action not allowed on your account
	 * 1000 Action allowed only on main account
	 * 1001 Wrong action
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.HostException e)
{
	/* other errors
	 * 
	 * 8 - Error in request
	 * 666 - Internal system error
	 * 999 - Internal system error
	 * 201 - Internal system error
	 * SMSApi.Api.HostException.E_JSON_DECODE - problem with data parsing
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.ProxyException e)
{
	// problem with connection between server and client
	System.Console.WriteLine(e.Message);
}
```

## Requirements

* C# >= 3.5 + System.Runtime.Serialization, System.ServiceModel.Web
* C# >= 4.0

## LICENSE
[Apache 2.0 License](https://github.com/smsapicom/smsapicom-php-client/blob/master/LICENSE)
