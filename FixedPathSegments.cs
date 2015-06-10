namespace Kombit.Samples.Common
{
    /// <summary>
    ///     Defines string contants to map a request path to a respective file
    /// </summary>
    public static class FixedPathSegments
    {
        /// <summary>
        ///     Constants for the AttributServicesController class
        /// </summary>
        public static readonly string[] AttributServicesController =
        {
            "AttributServices", "Anvenderkontekster",
            "Aktiveringstidspunkt", "SamlMetadata"
        };

        /// <summary>
        ///     Constants for the BrugersystemrollerController class
        /// </summary>
        public static readonly string[] BrugersystemrollerController =
        {
            "Brugersystemroller", "Aktiveringstidspunkt",
            "Dataafgraensningstyper"
        };

        /// <summary>
        ///     Constants for the BrugervendteSystemerController class
        /// </summary>
        public static readonly string[] BrugervendteSystemerController =
        {
            "BrugervendteSystemer", "RoleMappings",
            "SamlMetadata"
        };

        /// <summary>
        ///     Constants for the IdentityProvidersController class
        /// </summary>
        public static readonly string[] IdentityProvidersController =
        {
            "IdentityProviders", "Anvenderkontekster",
            "Aktiveringstidspunkt", "AssuranceLevel", "Beskrivelse", "KenderRoller", "Mobilvenlig", "Praesentationsnavn",
            "SamlMetadata", "IpAddresser"
        };

        /// <summary>
        ///     Constants for the JobfunktionsrollerController class
        /// </summary>
        public static readonly string[] JobfunktionsrollerController =
        {
            "Jobfunktionsroller", "Aktiveringstidspunkt",
            "DelegeretTil"
        };

        /// <summary>
        ///     Constants for the AnvendersystemerController class
        /// </summary>
        public static readonly string[] AnvendersystemerController =
        {
            "Anvendersystemer", "Anvenderkontekster",
            "ImpersonationAssignments", "RoleAssignments", "OcesCertifikater"
        };

        /// <summary>
        ///     Constants for the ServiceController class
        /// </summary>
        public static readonly string[] ServiceController = {"Service", "ServiceMetadata"};

        /// <summary>
        ///     Constants for the ServicesystemrollerController class
        /// </summary>
        public static readonly string[] ServicesystemrollerController =
        {
            "Servicesystemroller", "Aktiveringstidspunkt",
            "Dataafgraensningstyper"
        };

        /// <summary>
        ///     Constants for the StsController class
        /// </summary>
        public static readonly string[] StsController = {"api", "rest", "wstrust", "v1", "issue"};
    }
}