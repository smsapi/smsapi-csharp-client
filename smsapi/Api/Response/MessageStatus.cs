using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    public class MessageStatus
    {
        public readonly string Error;

        [JsonRequired]
        public readonly string ID;

        [JsonProperty("idx")]
        public readonly string IDx;

        [JsonRequired]
        public readonly string Number;

        [JsonRequired]
        public readonly double Points;

        [JsonRequired]
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
