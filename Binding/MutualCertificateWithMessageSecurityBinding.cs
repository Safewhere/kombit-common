#region

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

#endregion

namespace Kombit.Samples.Common.Binding
{
    /// <summary>
    ///     A custom binding which uses mutual certificate message security over https
    /// </summary>
    public class MutualCertificateWithMessageSecurityBinding : CustomBinding
    {
        /// <summary>
        ///     Creates a binidng with a specific signing algorithm method
        /// </summary>
        /// <param name="algorithmMethod">A signing algorithm method</param>
        public MutualCertificateWithMessageSecurityBinding(SigningAlgorithmMethod algorithmMethod)
            : base(CreateBindingElements(algorithmMethod, null))
        {
        }

        /// <summary>
        ///     Creates a binidng with a specific signing algorithm method and a custom factory to create a message encoding
        ///     element
        /// </summary>
        /// <param name="algorithmMethod">A signing algorithm method</param>
        /// <param name="messageEncodingElementFunc"></param>
        public MutualCertificateWithMessageSecurityBinding(SigningAlgorithmMethod algorithmMethod,
            Func<MessageEncodingBindingElement> messageEncodingElementFunc)
            : base(CreateBindingElements(algorithmMethod, messageEncodingElementFunc))
        {
        }

        /// <summary>
        ///     Creates binding elements
        /// </summary>
        /// <param name="algorithmMethod">Algorithm method to use</param>
        /// <param name="encodingElementFunc">Encoding element factory</param>
        /// <returns></returns>
        private static BindingElementCollection CreateBindingElements(SigningAlgorithmMethod algorithmMethod,
            Func<MessageEncodingBindingElement> encodingElementFunc)
        {
            //return base.CreateBindingElements();
            var bindings = new BindingElementCollection();
            var transportBinding = CreateTransportBindingElement();
            var encodingBinding = CreateEncodingBindingElement(encodingElementFunc);
            var securityBinding = CreateSecurityBindingElement(algorithmMethod);
            bindings.Add(securityBinding);
            bindings.Add(encodingBinding);
            bindings.Add(transportBinding);

            return bindings;
        }

        /// <summary>
        ///     Creates transport binding element
        /// </summary>
        /// <returns>an instance of type HttpsTransportBindingElement</returns>
        private static HttpTransportBindingElement CreateTransportBindingElement()
        {
            // set to true will IdentityModelServiceAuthorizationManager.GetTransportTokenIdentities which will invoke the CertificateSecurityTokenHandler.ValidateToken one more time which results in duplicate claims
            return new HttpsTransportBindingElement {RequireClientCertificate = false};
        }

        /// <summary>
        ///     Creates encoding binding element
        /// </summary>
        /// <param name="encodingElementFunc">Encoding binding element factory</param>
        /// <returns>An instance of type TextMessageEncodingBindingElement</returns>
        private static MessageEncodingBindingElement CreateEncodingBindingElement(
            Func<MessageEncodingBindingElement> encodingElementFunc)
        {
            if (encodingElementFunc != null)
            {
                return encodingElementFunc();
            }

            var messageEncodingBindingElement = new TextMessageEncodingBindingElement()
            {
                MessageVersion = MessageVersion.Soap11WSAddressing10
            };
            return messageEncodingBindingElement;
        }

        /// <summary>
        ///     Creates a AsymmetricSecurityBindingElement
        /// </summary>
        /// <param name="signingAlgorithm">Signing algorithm</param>
        /// <returns>An instance of type AsymmetricSecurityBindingElement</returns>
        private static SecurityBindingElement CreateSecurityBindingElement(SigningAlgorithmMethod signingAlgorithm)
        {
            var messageSecurity = new AsymmetricSecurityBindingElement();
            messageSecurity.AllowSerializedSigningTokenOnReply = true;
            messageSecurity.MessageSecurityVersion =
                MessageSecurityVersion
                    .WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            if (signingAlgorithm == SigningAlgorithmMethod.Sha256)
                messageSecurity.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128Sha256;
            var x509SecurityParamter = new X509SecurityTokenParameters(
                X509KeyIdentifierClauseType.Any, SecurityTokenInclusionMode.AlwaysToInitiator);
            messageSecurity.RecipientTokenParameters = x509SecurityParamter;
            messageSecurity.RecipientTokenParameters.RequireDerivedKeys = false;
            var initiator = new X509SecurityTokenParameters(X509KeyIdentifierClauseType.Any,
                SecurityTokenInclusionMode.AlwaysToRecipient) {RequireDerivedKeys = false};
            messageSecurity.InitiatorTokenParameters = initiator;

            messageSecurity.MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign;
            messageSecurity.LocalClientSettings.MaxClockSkew = new TimeSpan(0,0,1,0);
            messageSecurity.LocalClientSettings.TimestampValidityDuration = new TimeSpan(0, 0, 10, 0);
            messageSecurity.LocalServiceSettings.MaxClockSkew = new TimeSpan(0, 0, 1, 0);
            messageSecurity.LocalClientSettings.TimestampValidityDuration = new TimeSpan(0,0,10,0);

            return messageSecurity;
        }
    }
}