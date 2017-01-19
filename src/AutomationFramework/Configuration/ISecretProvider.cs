namespace Mjcheetham.AppiumTesting.Automation.Configuration
{
    interface ISecretProvider
    {
        string GetSecret(string secretName);
    }
}
