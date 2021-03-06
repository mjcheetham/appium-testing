﻿using System.Security.Cryptography.X509Certificates;

namespace Mjcheetham.AppiumTesting.Configuration
{
    interface ICertificateProvider
    {
        X509Certificate2 FindCertificateByThumbprint(string thumbprint);
    }
}
