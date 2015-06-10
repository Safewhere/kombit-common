namespace Kombit.Samples.Common.WSTrust13
{
    /// <summary>
    /// Defines contants for WSTrust messages
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Key types
        /// </summary>
        public static class KeyTypes
        {
            /// <summary>
            /// Indicates that a request wants to use Asymmetric key
            /// </summary>
            public const string Asymmetric = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/PublicKey";

            /// <summary>
            /// Indicates that a request wants to use bearer key
            /// </summary>
            public const string Bearer = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer";

            /// <summary>
            /// Indicates that a request wants to use Symmetric key
            /// </summary>
            public const string Symmetric = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey";
        }

        /// <summary>
        /// Token types
        /// </summary>
        public static class TokenTypes
        {
            /// <summary>
            /// Saml 1.1 token
            /// </summary>
            public const string OasisWssSaml11TokenProfile11 = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";

            /// <summary>
            /// Saml 2.0 token
            /// </summary>
            public const string OasisWssSaml2TokenProfile11 = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0";

            /// <summary>
            /// Saml assertion 1.0
            /// </summary>
            public const string Saml11TokenProfile11 = "urn:oasis:names:tc:SAML:1.0:assertion";

            /// <summary>
            /// Saml assertion 2.0
            /// </summary>
            public const string Saml2TokenProfile11 = "urn:oasis:names:tc:SAML:2.0:assertion";
        }
    }
}
