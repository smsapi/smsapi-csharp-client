namespace SMSApi.Api.Action;

public interface IPaginable
{
    uint? Limit { get; set; }
    
    uint? Offset { get; set; }
}
