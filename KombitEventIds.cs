namespace Kombit.Samples.Common
{
    /// <summary>
    ///     Some constants for STS
    /// </summary>
    public static class KombitConstants
    {
        // A dummy AppliesTo field
        public static string DummyAppliesToError = "http://kombit.samples.local/";
    }

    /// <summary>
    ///     EventIds of the returned error response
    /// </summary>
    public static class KombitEventIds
    {
        /// <summary>
        /// No connection found error 
        /// </summary>
        public const int ConnectionNotFoundError = 5002;
        /// <summary>
        /// Authentication failed error
        /// </summary>
        public const int AuthenticationFailedError = 5607;
        /// <summary>
        /// Bad request error: such as missing cvr, ...
        /// </summary>
        public const int CvrIsEmptyError = 5015;
    }
}