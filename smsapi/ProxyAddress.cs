namespace SMSApi.Api
{
    public enum ProxyAddress
    {
        SmsApiIo,
        SmsApiPl,
        BackupSmsApiPl,
        SmsApiCom,
        BackupSmsApiCom
    }

    public static class ProxyAddressExtensions
    {
        public static string GetUrl(this ProxyAddress proxy)
        {
            switch (proxy)
            {
                case ProxyAddress.SmsApiIo:
                    return "https://smsapi.io/";

                case ProxyAddress.SmsApiPl:
                    return "https://api.smsapi.pl/";

                case ProxyAddress.BackupSmsApiPl:
                    return "https://api2.smsapi.pl/";

                case ProxyAddress.SmsApiCom:
                    return "https://api.smsapi.com/";

                case ProxyAddress.BackupSmsApiCom:
                    return "https://api2.smsapi.com/";
            }

            throw new ProxyException("Proxy address does not exist.");
        }
    }
}
