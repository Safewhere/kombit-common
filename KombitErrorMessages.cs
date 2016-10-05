namespace Kombit.Samples.Common
{
    /// <summary>
    ///     Common error messages when requesting a token from the STS
    /// </summary>
    public static class KombitErrorMessages
    {
        /// <summary>
        ///     Connection not found error message
        /// </summary>
        public const string ConnectionNotFoundError = "Path resolution: no connection '{0}' found";

        /// <summary>
        ///     Authentication failed error message
        /// </summary>
        public const string AuthenticationFailedError = "No mapped user exists for thumbprint '{0}'";

        /// <summary>
        ///     Bad request error message
        /// </summary>
        public const string CvrIsEmptyError = "It is expected that the received STR must contain a CVR claim. Please check to make sure it includes the CVR claim.";
    }
}