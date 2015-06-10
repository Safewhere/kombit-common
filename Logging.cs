#region

using Serilog;

#endregion

namespace Kombit.Samples.Common
{
    /// <summary>
    ///     Provides a logger object that all projects can have access to. Keep it simple.
    /// </summary>
    public static class Logging
    {
        /// <summary>
        ///     A singleton instance of a logger
        /// </summary>
        public static readonly ILogger Instance =
            new LoggerConfiguration().ReadAppSettings().WriteTo.RollingFile("Logs\\log-{Date}.txt").CreateLogger();
    }
}