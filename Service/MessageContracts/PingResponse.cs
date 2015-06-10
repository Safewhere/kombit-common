using System.Net.Security;
using System.ServiceModel;
using Kombit.Samples.Common.CustomHeaders;

namespace Kombit.Samples.Common.Service.MessageContracts
{
    /// <summary>
    ///     A class represents response to client on ping request
    /// </summary>
    [MessageContract]
    public class PingResponse
    {
        /// <summary>
        /// Framework element use in response header
        /// </summary>
        [MessageHeader(Namespace = "urn:liberty:sb:2006-08", MustUnderstand = true, Name = "Framework",
            ProtectionLevel = ProtectionLevel.Sign)] public LibertyFrameworkHeader Framework;

        /// <summary>
        /// Message to response to client
        /// </summary>
        [MessageBodyMember(Namespace = "http://kombit.samples.local/", Name = "structure",
            ProtectionLevel = ProtectionLevel.Sign)] public string MessageToResponse;
    }
}