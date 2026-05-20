using Newtonsoft.Json;

namespace SMSApi.Api.Response.ResponseResolver;

public class ErrorAwareResponse : IResponseCodeAwareResolver
{
    [JsonProperty("message")] public readonly string ErrorMessage;

    [JsonProperty("error")] public readonly string? ErrorCode;

    public bool IsError()
    {
        if (string.IsNullOrEmpty(ErrorCode)) return false;

        return ErrorCode != "0";
    }

    public string GetErrorMessage()
    {
        return ErrorMessage;
    }
}
