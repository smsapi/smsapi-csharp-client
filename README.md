csharp-client
===========

Klient napisany w jêzyku C#, pozwalaj¹cy na wysy³anie wiadomoœci SMS, MMS, VMS oraz zarz¹dzanie kontem w serwisie SMSAPI.pl

Przyk³ad wysy³ki sms:
```c#
try
{
	var smsApi = new SMSApi.Api.SMSFactory(client());


	var result =
		smsApi.ActionSend()
			.SetText("test message")
			.SetTo("694562829")
			.SetDateSent(DateTime.Now.AddHours(2))
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

	var deleted =
		smsApi
			.ActionDelete()
				.Id(ids)
				.Execute();

	System.Console.WriteLine("Deleted: " + deleted.Count);
}
catch (SMSApi.Api.ActionException e)
{
	/**
	 * B³êdy zwi¹zane z akcj¹ (z wy³¹czeniem b³êdów 101,102,103,105,110,1000,1001 i 8,666,999,201)
	 * http://www.smsapi.pl/sms-api/kody-bledow
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.ClientException e)
{
	/**
	 * 101 Niepoprawne lub brak danych autoryzacji.
	 * 102 Nieprawid³owy login lub has³o
	 * 103 Brak punków dla tego u¿ytkownika
	 * 105 B³êdny adres IP
	 * 110 Us³uga nie jest dostêpna na danym koncie
	 * 1000 Akcja dostêpna tylko dla u¿ytkownika g³ównego
	 * 1001 Nieprawid³owa akcja
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.HostException e)
{
	/* b³¹d po stronie servera lub problem z parsowaniem danych
	 * 
	 * 8 - B³¹d w odwo³aniu
	 * 666 - Wewnêtrzny b³¹d systemu
	 * 999 - Wewnêtrzny b³¹d systemu
	 * 201 - Wewnêtrzny b³¹d systemu
	 * SMSApi.Api.HostException.E_JSON_DECODE - problem z parsowaniem danych
	 */
	System.Console.WriteLine(e.Message);
}
catch (SMSApi.Api.ProxyException e)
{
	// b³¹d w komunikacji pomiedzy klientem i serverem
	System.Console.WriteLine(e.Message);
}
```
