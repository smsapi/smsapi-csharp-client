using System.Linq;
using SMSApi.Api;
using SMSApi.Api.Response.Deserialization;

namespace smsapi.Api.Response.REST.Exception;

public class ValidationException : ClientException
{
    public readonly ValidationErrorsResolver.ValidationErrors ValidationErrors;
    
    private ValidationException(ValidationErrorsResolver.ValidationErrors validationErrors, string message) : base(message, 400)
    {
        ValidationErrors = validationErrors;
    }

    public static ValidationException Create(ValidationErrorsResolver.ValidationErrors validationErrors)
    {
        var errorMessages = validationErrors.Errors
            .Select(error => $"{error.Error}: {error.Message}")
            .ToList();

        var errorMessage = string.Join(", ", errorMessages);

        return new ValidationException(validationErrors, errorMessage);
    }
}
