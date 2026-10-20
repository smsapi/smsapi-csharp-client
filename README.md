SMSAPI C# client
================

[![NuGet](https://img.shields.io/nuget/v/SMSAPI.pl.svg)](https://www.nuget.org/packages/SMSAPI.pl)

Client library for the [SMSAPI](https://www.smsapi.com) messaging platform. Works with *smsapi.io*, *smsapi.pl*
and *smsapi.com* accounts.

## Requirements

* .NET 6.0 or newer (`net6.0`, `net7.0`, `net8.0`, `net9.0`, `net10.0`)

### Dependencies

Installed automatically by NuGet:

* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) >= 13.0.3

No other third-party packages are required. HTTP communication uses the built-in `System.Net.Http.HttpClient`.

## Installation

```bash
dotnet add package SMSAPI.pl
```

or in Package Manager Console:

```powershell
Install-Package SMSAPI.pl
```

## Quick start

```c#
using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var result = features.SMS()
    .ActionSend("4850010010", "Hello world")
    .SetSender("Test")
    .Execute();

Console.WriteLine($"Sent: {result.Count}");
```

More examples for every feature are in the [`examples/`](examples) directory.

## Authentication

Only OAuth bearer tokens are supported. Generate a token in the SMSAPI panel
([smsapi.pl](https://ssl.smsapi.pl/webapp#/oauth/manage) / [smsapi.com](https://ssl.smsapi.com/webapp#/oauth/manage))
and pass it to `ClientOAuth`:

```c#
var client = new ClientOAuth("token");
```

Basic (username/password) authentication was removed in 3.0.

## How to pick a service?

`Features` (and every `*Factory`) accepts a `ProxyAddress`. Default is *smsapi.io*.

```c#
var features = new Features(client);                          // smsapi.io (default)
var features = new Features(client, ProxyAddress.SmsApiPl);   // api.smsapi.pl
var features = new Features(client, ProxyAddress.SmsApiCom);  // api.smsapi.com
```

Backup endpoints `ProxyAddress.BackupSmsApiPl` and `ProxyAddress.BackupSmsApiCom` are available as well.

## Features

Every feature is reached through an extension method on `Features`:

| Feature | Accessor | Examples |
|---|---|---|
| SMS (send, get status, delete scheduled, fallback, templates) | `features.SMS()` | [examples/sms](examples/sms) |
| MMS | `features.MMS()` | [examples/mms](examples/mms) |
| VMS (text-to-speech, audio file) | `features.VMS()` | [examples/vms](examples/vms) |
| HLR lookups | `features.HLR()` | [examples/hlr](examples/hlr) |
| MFA codes | `features.MFA()` | [examples/mfa](examples/mfa) |
| Sender names | `features.Sendernames()` | [examples/sendernames](examples/sendernames) |
| Short URLs | `features.ShortUrl()` | [examples/shortUrl](examples/shortUrl) |
| Contacts, groups, fields | `features.Contacts()` | [examples/contacts](examples/contacts) |
| Subusers | `features.Subusers()` | [examples/subusers](examples/subusers) |
| Blacklist | `features.Blacklist()` | [examples/blacklist](examples/blacklist) |
| Opt-out | `features.OptOut()` | [examples/optOut](examples/optOut) |
| Profile, points | `features.Profile()` | [examples/profile](examples/profile) |
| Prices | `features.Prices()` | [examples/profile/prices](examples/profile/prices) |
| Ping | `features.Ping()` | [examples/ping](examples/ping) |

Listings support pagination through `Limit` / `Offset` — see [examples/Pagination.cs](examples/Pagination.cs).

## Async

Every action can be executed asynchronously:

```c#
var result = await features.SMS()
    .ActionSend("4850010010", "Hello world")
    .ExecuteAsync(cancellationToken);
```

## Custom HttpClient and proxy

By default the library creates its own `HttpClient`. To reuse your own instance (e.g. configured with a web proxy,
timeouts or `IHttpClientFactory`), pass it to `Features`:

```c#
var httpClient = new HttpClient(new HttpClientHandler
{
    Proxy = new WebProxy("http://proxy.example.com:8080"),
});

var features = new Features(client, httpClient, ProxyAddress.SmsApiPl);
```

To point the client at a different base URL (e.g. a test environment), build the transport yourself:

```c#
var proxy = new ProxyHTTP("https://api.example.com", httpClient);
var features = new Features(client, proxy);
```

## Error handling

All API errors derive from `SmsapiException`, which exposes the error `Code` and, where available, the raw API
`Response`.

```c#
try
{
    var result = features.SMS()
        .ActionSend("4850010010", "Hello world")
        .Execute();
}
catch (ActionException e)
{
    // Action error, e.g. invalid sender name, empty message
    Console.WriteLine($"{e.Code}: {e.Message}");
}
catch (ClientException e)
{
    // Client error, e.g. 101 invalid token, 103 insufficient credits
    // (full list of codes in the SMSAPI docs: https://www.smsapi.pl/docs)
    Console.WriteLine($"{e.Code}: {e.Message}");
}
catch (HostException e)
{
    // Server error or malformed API response (code -1, raw body in e.Response)
    Console.WriteLine($"{e.Code}: {e.Message}");
}
catch (ProxyException e)
{
    // Communication problem between the client and the server
    Console.WriteLine(e.Message);
}
```

REST endpoints (contacts, sender names, short URLs, subusers, opt-out, blacklist, MFA, HLR) additionally throw typed
exceptions from `smsapi.Api.Response.REST.Exception` — `ValidationException` (with `ValidationErrors`),
`NotFoundException` (base for feature-specific ones like `OptOutNotFoundException`), `UnauthorizedException`, `AccessForbiddenException`, `TooManyRequestsException`,
`ServiceUnavailableException` — and feature-specific ones such as `ContactAlreadyExistsException` or
`ShortUrlWithNameAlreadyExistsException`.

## Upgrading from 2.x

See [CHANGELOG.md](CHANGELOG.md) for the full list of breaking changes in 3.0.

## License

[Apache 2.0 License](smsapi/docs/LICENSE.md)
