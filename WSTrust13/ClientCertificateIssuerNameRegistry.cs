using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Kombit.Samples.Common.WSTrust13
{
    public class ClientCertificateIssuerNameRegistry : IssuerNameRegistry
    {
        private readonly string[] certificateIdentifyingValues;
        private readonly bool checkIssuer;
        
        public ClientCertificateIssuerNameRegistry(bool checkIssuer, params string[] certificateIdentifyingValues)
        {
            this.checkIssuer = checkIssuer;
            this.certificateIdentifyingValues = certificateIdentifyingValues;
        }

        public override string GetIssuerName(SecurityToken securityToken)
        {
            X509SecurityToken x509SecurityToken = securityToken as X509SecurityToken;
            if (x509SecurityToken == null)
                throw new ArgumentException("securityToken");
            X509Certificate2 cert = x509SecurityToken.Certificate;
            if (!checkIssuer)
                return cert.Subject;

            if (certificateIdentifyingValues == null)
                return null;

            if (certificateIdentifyingValues.Any(s => s.Equals(cert.Thumbprint, StringComparison.OrdinalIgnoreCase)))
                return cert.Subject;

            return null;
        }
    }
}
