using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class MessageStatus
    {
        private MessageStatus() 
        {
            ID = "";
            Points = 0;
            Number = "";
            Status = "UNKNOWN";
            Error = null;
            IDx = null;
        }

        public bool isError()
        {
            if (ID == null || ID.Length == 0) return true;
            if (Error != null) return true;
            
            return false;
        }

        public bool isFinal()
        {
            if (isError()) return true;

            if (Status.Equals("QUEUE")) return false;
            if (Status.Equals("SENT")) return false;

            return true;
        }

        [DataMember(Name = "id", IsRequired = true)]
        public readonly string ID;

        [DataMember(Name = "points", IsRequired = true)]
        public readonly double Points;

        [DataMember(Name = "number", IsRequired = true)]
        public readonly string Number;

        [DataMember(Name = "status", IsRequired = true)]
        public readonly string Status;

        [DataMember(Name = "error", IsRequired = false)]
        public readonly string Error;

        [DataMember(Name = "idx", IsRequired = false)]
        public readonly string IDx;
    }
}
