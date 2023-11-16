using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Profile.Prices;
using smsapiTests.Unit.Action.Profile.Prices.Fixture;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Profile.Prices;

[TestClass]
public class GetPricesTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void empty_list()
    {
        var response = PricesCollectionMother.EmptyCollection();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetPrices().Execute();

        Assert.AreEqual(0, result.Size);
    }

    [TestMethod]
    public void list_prices()
    {
        var amount = 15.14f;
        var currency = "EUR";
        var countryName = "USA";
        var mcc = 310;
        var networkName = "Verizon";
        var mnc = 10;
        var type = "hlr";

        var response = PricesCollectionMother.SinglePrice(
            amount,
            currency,
            countryName,
            mcc,
            networkName,
            mnc,
            type
        );
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetPrices().Execute();

        Assert.AreEqual(1, result.Size);
        var firstResult = result.Collection.First();
        Assert.AreEqual(countryName, firstResult.Country.Name);
        Assert.AreEqual(mcc, firstResult.Country.MCC);
        Assert.AreEqual(networkName, firstResult.Network.Name);
        Assert.AreEqual(mnc, firstResult.Network.MNC);
        Assert.AreEqual(amount, firstResult.Price.Amount);
        Assert.AreEqual(currency, firstResult.Price.Currency);
        Assert.AreEqual(type, firstResult.Type);
    }

    private GetPrices GetPrices()
    {
        var action = new GetPrices();
        action.Proxy(_proxyStub);

        return action;
    }
}
