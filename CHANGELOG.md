# CHANGELOG.md

## 3.0.0 (unreleased)

- VMS: fixed sending audio file (`SetFile`) - file was dropped from request
- VMS: fixed `SetGroup` - `group` parameter was not sent
- VMS: added `SetFileUrl` and `SetFile(FileInfo)`
- Blacklist: `Remove` with empty id throws `ArgumentException` instead of removing whole blacklist (same validation for `DeleteShortUrl`, `DeleteOptOut`, `DeleteSendername`, `DeleteSubuser`)
- Sending files with JSON content type throws instead of silently dropping them
- `SmsapiException.Response` holds the raw API response; set when response deserialization fails (`HostException` with code `-1`, instead of a raw `JsonSerializationException`) and for `UnhandledRestException`
- **BC**: `ShortLink.ExpireAt` is `DateTime?`
- **BC**: `LookupResult.ErrorCode` is `string?` (API returns textual codes, e.g. `TELESERVICE_NOT_PROVISIONED`)
- **BC**: `Contact.BirthdayDate` is `DateTime?`

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
