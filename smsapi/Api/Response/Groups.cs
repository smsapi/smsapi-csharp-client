using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Groups : BasicCollection<Group>
    {
        private Groups() : base() { }
    }
}
