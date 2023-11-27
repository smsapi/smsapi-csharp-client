using SMSApi.Api;

var client = new ClientOAuth("token");
var features = new Features(client);

features.Blacklist()
    .RemoveAll()
    .Execute();

//cleaning blacklist has been scheduled at this point
