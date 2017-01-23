using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Mjcheetham.AppiumTesting.Configuration
{
    public class AzureKeyVaultSecretProvider : ISecretProvider
    {
        private readonly Uri vaultUrl;
        private readonly ClientAssertionCertificate clientAssertCert;
        private readonly IKeyVaultClient vaultClient;

        public AzureKeyVaultSecretProvider(Uri vaultUrl, string clientId, X509Certificate2 authCertificate)
        {
            if (vaultUrl == null)
            {
                throw new ArgumentNullException(nameof(vaultUrl));
            }

            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (authCertificate == null)
            {
                throw new ArgumentNullException(nameof(authCertificate));
            }

            this.vaultUrl = vaultUrl;
            this.clientAssertCert = new ClientAssertionCertificate(clientId, authCertificate);

            this.vaultClient = new KeyVaultClient(this.GetVaultAccessTokenAsync);
        }

        private async Task<string> GetVaultAccessTokenAsync(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            AuthenticationResult authResult = await authContext.AcquireTokenAsync(resource, this.clientAssertCert).ConfigureAwait(false);
            return authResult.AccessToken;
        }

        #region ISecretProvider

        public string GetSecret(string secretName)
        {
            if (string.IsNullOrWhiteSpace(secretName))
            {
                throw new ArgumentNullException(nameof(secretName));
            }

            SecretBundle bundle = this.vaultClient.GetSecretAsync(this.vaultUrl.ToString(), secretName, CancellationToken.None)
                                                  .ConfigureAwait(false)
                                                  .GetAwaiter()
                                                  .GetResult();
            return bundle.Value;
        }

        #endregion
    }
}
