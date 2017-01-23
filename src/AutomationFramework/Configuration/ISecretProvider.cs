namespace Mjcheetham.AppiumTesting.Configuration
{
    public interface ISecretProvider
    {
        string GetSecret(string secretName);
    }
}
