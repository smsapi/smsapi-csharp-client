using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class GroupPermission : ErrorAwareResponse, IResponseCodeAwareResolver
    {
        public readonly string GroupId;

        public readonly bool Read;

        public readonly bool Send;

        public readonly string Username;

        public readonly bool Write;
    }
}
