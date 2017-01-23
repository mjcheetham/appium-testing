using System;

namespace Mjcheetham.AppiumTesting.Configuration
{
    public static class SecretProviderExtensions
    {
        public static T GetSecret<T>(this ISecretProvider secretProvider, string secretName)
        {
            if (secretProvider == null)
            {
                throw new ArgumentNullException(nameof(secretProvider));
            }

            if (string.IsNullOrWhiteSpace(secretName))
            {
                throw new ArgumentNullException(nameof(secretName));
            }

            string secretStr = secretProvider.GetSecret(secretName);

            return (T)Convert.ChangeType(secretStr, typeof(T));
        }
    }
}
