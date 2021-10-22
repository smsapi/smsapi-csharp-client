csharp-client
===========

SMSAPI C# client may be used by *SMSAPI.pl* and *SMSAPI.com* clients.

## How to pick a service?

### *SMSAPI.PL* (default)

```c#
var smsApi = new SMSApi.Api.SMSFactory(client);
//or
var smsApi = new SMSApi.Api.SMSFactory(client, ProxyAddress.SmsApiPl);
```

### *SMSAPI.COM*

```c#
var smsApi = new SMSApi.Api.SMSFactory(client, ProxyAddress.SmsApiCom);
```


### Example

```c#
try
{
	SMSApi.Api.IClient client = new SMSApi.Api.ClientOAuth("token");

	var smsApi = new SMSApi.Api.SMSFactory(client);
	// for SMSAPI.com clients:
	// var smsApi = new SMSApi.Api.SMSFactory(client, ProxyAddress.SmsApiCom);

	var result =
		smsApi.ActionSend()
			.SetText("test message")
			.SetTo("0000000000")
			.SetSender("Test") //Sender name
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
}
catch (SMSApi.Api.ActionException e)
{
	/**
	 * Action error
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.ClientException e)
{
	/**
	 * Error codes (list available in smsapi docs). Example:
	 * 101 	Invalid authorization info
	 * 102 	Invalid username or password
	 * 103 	Insufficient credits on Your account
	 * 104 	No such template
	 * 105 	Wrong IP address (for IP filter turned on)
	 * 110	Action not allowed for your account
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.HostException e)
{
	/* 
	 * Server errors
	 * SMSApi.Api.HostException.E_JSON_DECODE - problem with parsing data
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.ProxyException e)
{
	// communication problem between client and sever
	System.Console.WriteLine(e.Message);
}
```

## Requirements

* C# >= 3.5 + System.Runtime.Serialization, System.ServiceModel.Web
* C# >= 4.0

## LICENSE
[Apache 2.0 License](https://github.com/smsapi/smsapi-php-client/blob/master/LICENSE)
