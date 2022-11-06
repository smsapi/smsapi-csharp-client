using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class NumberStatus
    {
        [DataMember(Name = "date", IsRequired = false)]
        public readonly int Date;

        [DataMember(Name = "id", IsRequired = false)]
        public readonly string ID;

        [DataMember(Name = "info", IsRequired = false)]
        public readonly string Info;

        [DataMember(Name = "mcc", IsRequired = false)]
        public readonly int MCC;

        [DataMember(Name = "mnc", IsRequired = false)]
        public readonly int MNC;

        [DataMember(Name = "number", IsRequired = true)]
        public readonly string Number;

        [DataMember(Name = "price", IsRequired = false)]
        public readonly double Points;

        [DataMember(Name = "ported", IsRequired = false)]
        public readonly int Ported;

        [DataMember(Name = "ported_from", IsRequired = false)]
        public readonly int PortedFrom;

        [DataMember(Name = "status", IsRequired = false)]
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
