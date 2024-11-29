using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var optOutList = features.OptOut()
    .List()
    .Execute();

OptOutDeletionResponse DeleteOptOut(string optOutId)
{
    return features.OptOut()
        .DeleteOptOut(optOutId)
        .Execute();
}

optOutList.Collection.ForEach(opt =>
{
    try
    {
        DeleteOptOut(opt.Id);

        //optOut is deleted at this point
        Console.WriteLine($"Deleted opt out {opt.Id}");
    }
    catch (OptOutNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
});
