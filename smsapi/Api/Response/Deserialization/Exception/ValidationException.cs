using System.Linq;
using SMSApi.Api;
using SMSApi.Api.Response.Deserialization;

namespace smsapi.Api.Response.Deserialization.Exception;

public class ValidationException : ClientException
{
    private ValidationException(string message) : base(message, 400)
    {
    }

    public static ValidationException Create(ValidationErrorsResolver.ValidationErrors validationErrors)
    {
        var errorMessages = validationErrors.Errors
            .Select(error => $"{error.Error}: {error.Message}")
            .ToList();

        var errorMessage = string.Join(", ", errorMessages);

        return new ValidationException(errorMessage);
    }
}
