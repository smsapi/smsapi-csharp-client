using Newtonsoft.Json;

namespace SMSApi.Api.Response.ResponseResolver;

public class ErrorAwareResponse : IResponseCodeAwareResolver
{
    [JsonProperty("message")] public readonly string ErrorMessage;

    [JsonProperty("error")] public readonly int? ErrorCode;

    // [JsonProperty("error")]
    // private JsonElement? _errorCode
    // {
    //     set => value?.Let(val =>
    //     {
    //         ErrorCode = val.ValueKind == JsonValueKind.Number ? val.GetInt32() : val.GetString();
    //     });
    // }

    public bool IsError()
    {
        if (ErrorCode == null) return false;

      //  if (ErrorCode is string) return ErrorCode != "";

        return (ErrorCode as int? ?? 0) != 0;
    }

    public string GetErrorMessage()
    {
        return ErrorMessage;
    }
}
