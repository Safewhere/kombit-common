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
        ///     Common runtime error
        /// </summary>
        public const int CommonRuntimeError = 100;

        /// <summary>
        ///     Connection resolution error
        /// </summary>
        public const int ConnectionResolutionError = 101;

        /// <summary>
        ///     Malformed request error
        /// </summary>
        public const int MalformedRequestError = 103;

        /// <summary>
        ///     Path resolution error
        /// </summary>
        public const int PathResolutionError = 104;

        /// <summary>
        ///     Audit user request error
        /// </summary>
        public const int AuditUserRequestError = 106;

        /// <summary>
        ///     Not supported error
        /// </summary>
        public const int NotSupportedException = 110;

        /// <summary>
        ///     Configuration error
        /// </summary>
        public const int ConfigurationError = 111;

        /// <summary>
        ///     Database error
        /// </summary>
        public const int DatabaseError = 130;
    }
}