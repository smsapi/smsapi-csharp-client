using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Contacts : BasicCollection<Contact>
    {
        [Obsolete("")]
        public readonly int Total;
    }
}
