using System.Security.Cryptography.X509Certificates;

namespace Eytec.API.Security
{
    public class CertificateValidator
    {
        private readonly X509Certificate2Collection caCerts;

        public CertificateValidator()
        {
            // Load the certificate authority (CA) certificates
            X509Store store = new(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            caCerts = store.Certificates;
            store.Close();
        }

        public bool ValidateCertificate(X509Certificate2 certificate)
        {
            // Check if the certificate is valid and has been issued by a trusted CA
            if (certificate == null || !certificate.Verify())
            {
                return false;
            }

            // Check the certificate chain
            X509Chain chain = new();
            chain.ChainPolicy.ExtraStore.AddRange(caCerts);
            return chain.Build(certificate);
        }
    }

}
