# CHANGELOG.md

## 3.0.0 (2026-10-20)

### Breaking changes

- Basic (username/password) authentication removed — only `ClientOAuth` is supported
- RestSharp replaced with built-in `System.Net.Http.HttpClient`; RestSharp dependency dropped
- Dropped support for .NET < 6; targets `net6.0`–`net10.0`
- JSON property naming strategy changed to snake_case
- `SenderFactory` / `features.Sender()` deprecated in favour of `SendernamesFactory` / `features.Sendernames()`
- `UserFactory` / `features.User()` deprecated in favour of `SubUsersFactory` / `features.Subusers()`
- `ListContacts.SetLimit` / `SetOffset` deprecated in favour of `Limit` / `Offset` properties (`IPaginable`)
- HTTP error statuses are mapped to typed exceptions (`UnauthorizedException`, `AccessForbiddenException`, `NotFoundException`, `TooManyRequestsException`, `ServiceUnavailableException`, `ValidationException`, `UnhandledRestException`)
- `ShortLink.ExpireAt` is `DateTime?`
- `LookupResult.ErrorCode` is `string?` (API returns textual codes, e.g. `TELESERVICE_NOT_PROVISIONED`)
- `Contact.BirthdayDate` is `DateTime?`

### Added

- `Features` entry point with `features.SMS()`, `features.MMS()`, ... extension methods
- Async execution: `ExecuteAsync(CancellationToken)` on every action
- Custom `HttpClient` support: `new Features(client, httpClient)` / `new ProxyHTTP(url, httpClient)`
- Features: MFA codes, Blacklist, HLR lookups, Ping, Profile, Prices, Opt-out, Short URLs, Subusers, Sender names
- SMS: fallback to VMS (`WithFallback`), templates with parameters, deleting many scheduled messages at once
- VMS: `SetFileUrl` and `SetFile(FileInfo)`
- `SmsapiException.Response` holds the raw API response; set when response deserialization fails (`HostException` with code `-1`, instead of a raw `JsonSerializationException`) and for `UnhandledRestException`
- Pagination support (`Limit` / `Offset`) on listings
- Examples for every feature in `examples/`

### Fixed

- VMS: sending audio file (`SetFile`) — file was dropped from request
- VMS: `SetGroup` — `group` parameter was not sent
- Blacklist: `Remove` with empty id throws `ArgumentException` instead of removing whole blacklist (same validation for `DeleteShortUrl`, `DeleteOptOut`, `DeleteSendername`, `DeleteSubuser`)
- Sending files with JSON content type throws instead of silently dropping them
- Contacts: list limit/offset query, group id as string, nullable group count, field options listing
- Template message in SMS
- Proxy base URL accepted without trailing slash
- Short URL file name propagation and UTF-8 file names

## 2.2.1 (unreleased)

- Basic authentication deprecation

## 2.2.0 (2023-05-16)

- Http Client fixes [#36](https://github.com/smsapi/smsapi-csharp-client/issues/36), [#32](https://github.com/smsapi/smsapi-csharp-client/issues/32)
- RestSharp dependency update to 109.0.1
- Abandoned support for .NET < 6

## 2.1.0 (2023-04-12)

- Support for templates in SMS [#37](https://github.com/smsapi/smsapi-csharp-client/issues/33)

## 2.0.0 (2023-01-18)

- Support for smsapi.io
