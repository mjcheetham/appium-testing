namespace Mjcheetham.AppiumTesting.Configuration
{
    interface ISecretProvider
    {
        string GetSecret(string secretName);
    }
}
