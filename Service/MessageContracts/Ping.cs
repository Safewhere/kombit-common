using System.Net.Security;
using System.ServiceModel;
using Kombit.Samples.Common.CustomHeaders;

namespace Kombit.Samples.Common.Service.MessageContracts
{
    /// <summary>
    ///     Libertyheader must always be included on WCP calls
    /// </summary>
    [System.ServiceModel.MessageContract]
    public class Ping
    {
        /// <summary>
        /// Liberty framework element in message header
        /// </summary>
        [MessageHeader(Namespace = "urn:liberty:sb:2006-08", MustUnderstand = true, Name = "Framework",
            ProtectionLevel = ProtectionLevel.Sign)] public LibertyFrameworkHeader Framework;

        /// <summary>
        /// Message sent from client
        /// </summary>
        [MessageBodyMember(Namespace = "http://service.kombit.dk/", Name = "structure",
            ProtectionLevel = ProtectionLevel.Sign)] public string MessageToPing;
    }
}