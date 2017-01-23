using System.Security.Cryptography.X509Certificates;

namespace Mjcheetham.AppiumTesting.Configuration
{
    public class LocalCertificateProvider : ICertificateProvider
    {
        private readonly X509Store store;

        public LocalCertificateProvider()
            : this(StoreName.My, StoreLocation.CurrentUser) { }

        public LocalCertificateProvider(StoreName storeName, StoreLocation storeLocation)
        {
            this.store = new X509Store(storeName, storeLocation);
        }

        #region ICertificateStore

        public X509Certificate2 FindCertificateByThumbprint(string thumbprint)
        {
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindByThumbprint,
                    thumbprint, false); // Don't validate certs, since the test root isn't installed.

                if (col == null || col.Count == 0)
                {
                    return null;
                }

                return col[0];
            }
            finally
            {
                store.Close();
            }
        }

        #endregion
    }
}
