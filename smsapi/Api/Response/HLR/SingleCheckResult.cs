using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.HLR;

[DataContract]
public readonly record struct SingleCheckResult : IResponseCodeAwareResolver;
