using System.Security.Cryptography.X509Certificates;

namespace Mjcheetham.AppiumTesting.Automation.Configuration
{
    interface ICertificateProvider
    {
        X509Certificate2 FindCertificateByThumbprint(string thumbprint);
    }
}
