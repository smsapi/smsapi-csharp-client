namespace SMSApi.Api.Action;

public interface IPaginable
{
    int? Limit { get; set; }
    
    int? Offset { get; set; }
}
