using Mjcheetham.AppiumTesting.Configuration;
using OpenQA.Selenium.Remote;
using System;

namespace Mjcheetham.AppiumTesting
{
    public static class ConfigurationExtensions
    {
        public static DesiredCapabilities DesiredCapabilties(this DeviceConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var desiredCaps = new DesiredCapabilities();
            foreach (var cap in config.Capabilities)
            {
                desiredCaps.SetCapability(cap.Key, cap.Value);
            }
            return desiredCaps;
        }
    }
}
