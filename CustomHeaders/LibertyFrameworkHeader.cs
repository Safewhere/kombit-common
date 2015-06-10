namespace Kombit.Samples.Common.CustomHeaders
{
    /// <summary>
    /// A class represents a liberty framework element used in soap message header
    /// </summary>
    [System.Serializable]
    public class LibertyFrameworkHeader
    {
        private string sbfprofile;
        private string version;

        /// <summary>
        ///     Initializes a new instance of the LibertyFrameworkHeader class
        /// </summary>
        public LibertyFrameworkHeader()
        {
            version = "2.0";

            sbfprofile = "urn:liberty:sb:profile:basic";
        }
        /// <summary>
        ///     Version of liberty profile used in framework element
        /// </summary>
        [System.Xml.Serialization.XmlAttribute(AttributeName = "version")]
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        /// <summary>
        ///     Name of profile used in the message
        /// </summary>
        [System.Xml.Serialization.XmlAttribute(AttributeName = "profile", Namespace = "urn:liberty:sb:profile")]
        public string Profile
        {
            get { return sbfprofile; }
            set { sbfprofile = value; }
        }
    }
}