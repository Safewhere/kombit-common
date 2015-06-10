using System.Net.Security;
using System.ServiceModel;
using Kombit.Samples.Common.Binding.Data;
using Kombit.Samples.Common.Service.MessageContracts;

namespace Kombit.Samples.Common.Service.ServiceInterfaces
{
    /// <summary>
    ///     Uses xmlserializer instead of DataContractSerializer(DCS). Reason for this is, DCS serializes all datamembers as
    ///     XMLElements. Attributes is desired in the LibertyFrameworkHeader
    /// </summary>
    [ServiceContract(Name = "Provider", Namespace = "http://kombit.samples.local/",
        ProtectionLevel = ProtectionLevel.Sign)]
    [XmlSerializerFormat]
    public interface IService
    {
        [OperationContract(ReplyAction = "http://kombit.samples.local/PingResponse",
            Action = "http://kombit.samples.local/pingRequest", Name = "structure",
            ProtectionLevel = ProtectionLevel.Sign)]
        [FaultContract(typeof (FrameworkFault), ProtectionLevel = ProtectionLevel.Sign)]
        PingResponse Ping(Ping structureToPing);
    }
}