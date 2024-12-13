using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    public class NumberStatus
    {
        public readonly int Date;

        [JsonProperty("id")]
        public readonly string ID;

        public readonly string Info;

        public readonly int MCC;

        public readonly int MNC;

        [JsonRequired]
        public readonly string Number;

        [JsonProperty("price")]
        public readonly double Points;

        public readonly int Ported;

        public readonly int PortedFrom;

        public readonly string Status;

        private NumberStatus()
        {
            ID = "";
            Number = "";
            MCC = 0;
            MNC = 0;
            Info = null;
            Status = null;
            Date = 0;
            Ported = 0;
            PortedFrom = 0;
            Points = 0;
        }
    }
}
