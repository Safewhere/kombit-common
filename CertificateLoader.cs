#region

using System;
using System.Security.Cryptography.X509Certificates;

#endregion

namespace Kombit.Samples.Common
{
    /// <summary>
    ///     Helper methods to load certificates from store
    /// </summary>
    public static class CertificateLoader
    {
        /// <summary>
        ///     Loads certificate from LocalMachine/My with thumbprint
        /// </summary>
        /// <param name="thumbprint">Thumbprint of a certificate</param>
        /// <returns>The first found certificate</returns>
        public static X509Certificate2 LoadCertificateFromMyStore(string thumbprint)
        {
            return LoadCertificateFromStore(StoreName.My, StoreLocation.LocalMachine, thumbprint);
        }

        /// <summary>
        ///     Loads certificate from LocalMachine/TrustedPeople with thumbprint
        /// </summary>
        /// <param name="thumbprint">Thumbprint of a certificate</param>
        /// <returns>The first found certificate</returns>
        public static X509Certificate2 LoadCertificateFromTrustedPeopleStore(string thumbprint)
        {
            return LoadCertificateFromStore(StoreName.TrustedPeople, StoreLocation.LocalMachine, thumbprint);
        }

        /// <summary>
        ///     Loads certificate from a store with thumbprint
        /// </summary>
        /// <param name="storeLocation">A store location</param>
        /// <param name="thumbprint">Thumbprint of a certificate</param>
        /// <param name="storeName">Store name</param>
        /// <returns>The first found certificate</returns>
        private static X509Certificate2 LoadCertificateFromStore(StoreName storeName, StoreLocation storeLocation,
            string thumbprint)
        {
            if (string.IsNullOrEmpty(thumbprint))
                throw new ArgumentNullException("thumbprint");

            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            var result = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

            Logging.Instance.Debug(
                "Loading certificates whose thumbprint is {Thumbprint} from store {Store} and location {Location}. Found {Count} certificates.",
                thumbprint, storeName, storeLocation, result.Count);
            if (result.Count == 0)
            {
                throw new ArgumentException("No certificate whose thumbprint is " + thumbprint + " is not found.");
            }

            return result[0];
        }
    }
}