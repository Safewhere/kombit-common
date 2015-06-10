using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Text;

namespace Kombit.Samples.Common.Binding
{
    /// <summary>
    ///     A binding that supports Liberty Basic SOAP binding.
    /// </summary>
    public class MutualIssuedTokenWithMessageSecurityBinding : CustomBinding
    {
        /// <summary>
        ///     Instantiates an object of type MutualIssuedTokenWithMessageSecurityBinding
        /// </summary>
        public MutualIssuedTokenWithMessageSecurityBinding()
            : base(Create())
        {
        }

        /// <summary>
        ///     Creates a custom binding
        /// </summary>
        /// <returns>Created binding</returns>
        private static System.ServiceModel.Channels.Binding Create()
        {
            var httpsTransport = new TransportSSLBindingWithAnonomousAuthenticationAndWsdlGenereration();

            return CreateBinding(httpsTransport);
        }

        /// <summary>
        ///     Creates a binding that supports Liberty Basic SOAP binding.
        /// </summary>
        /// <param name="transport">Transport object that is used for the binding</param>
        /// <returns>The created binding</returns>
        private static System.ServiceModel.Channels.Binding CreateBinding(TransportBindingElement transport)
        {
            TextMessageEncodingBindingElement encodingBindingElement =
                new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8);

            var messageSecurity = new AsymmetricSecurityBindingElement();

            messageSecurity.AllowSerializedSigningTokenOnReply = true;
            messageSecurity.MessageSecurityVersion =
                MessageSecurityVersion
                    .WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            messageSecurity.RecipientTokenParameters = new X509SecurityTokenParameters(X509KeyIdentifierClauseType.Any,
                SecurityTokenInclusionMode.AlwaysToInitiator);
            messageSecurity.RecipientTokenParameters.RequireDerivedKeys = false;
            var initiator =
                new CustomizeIdStrIssuedSecurityTokenParameters(
                    "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0");
            messageSecurity.ProtectTokens = true;
            initiator.UseStrTransform = true;

            initiator.KeyType = SecurityKeyType.AsymmetricKey;
            initiator.RequireDerivedKeys = false;

            messageSecurity.InitiatorTokenParameters = initiator;

            var customBinding = new CustomBinding(encodingBindingElement, messageSecurity, transport);

            return customBinding;
        }
    }
}