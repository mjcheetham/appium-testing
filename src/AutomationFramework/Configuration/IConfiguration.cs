using System;
using System.Collections.Generic;

namespace Mjcheetham.AppiumTesting.Configuration
{
    public interface IConfiguration
    {
        Uri AutomationServerUrl { get; }

        IReadOnlyDictionary<string, string> Capabilities { get; }

        TimeSpan CommandTimeout { get; }

        TimeSpan ElementSearchTimeout { get; }

        PlatformType PlatformType { get; }
    }
}
