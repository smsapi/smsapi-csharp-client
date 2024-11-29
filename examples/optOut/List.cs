using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

var optOutList = features.OptOut()
    .List()
    .Execute();

optOutList.Collection.ForEach(opt =>
{
    Console.WriteLine(opt.Id);
    Console.WriteLine(opt.PhoneNumber);
    Console.WriteLine(opt.CreationTime);
});
