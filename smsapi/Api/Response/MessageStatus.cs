using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class MessageStatus
    {
        [DataMember(Name = "error", IsRequired = false)]
        public readonly string Error;

        [DataMember(Name = "id", IsRequired = true)]
        public readonly string ID;

        [DataMember(Name = "idx", IsRequired = false)]
        public readonly string IDx;

        [DataMember(Name = "number", IsRequired = true)]
        public readonly string Number;

        [DataMember(Name = "points", IsRequired = true)]
        public readonly double Points;

        [DataMember(Name = "status", IsRequired = true)]
        public readonly string Status;

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
            if (ID == null || ID.Length == 0)
            {
                return true;
            }

            if (Error != null)
            {
                return true;
            }

            return false;
        }

        public bool isFinal()
        {
            if (isError())
            {
                return true;
            }

            if (Status.Equals("QUEUE"))
            {
                return false;
            }

            if (Status.Equals("SENT"))
            {
                return false;
            }

            return true;
        }
    }
}
