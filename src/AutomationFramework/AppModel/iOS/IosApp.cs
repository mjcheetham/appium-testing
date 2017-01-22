using Mjcheetham.AppiumTesting.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Mjcheetham.AppiumTesting.AppModel.iOS
{
    public abstract class IosApp : App
    {
        public IosApp(DeviceConfiguration config)
        {
            this.Driver = new IOSDriver<IWebElement>(config.AutomationServerUrl, config.DesiredCapabilties(), config.CommandTimeout);
            this.Driver.Manage().Timeouts().ImplicitlyWait(config.ElementSearchTimeout);
        }

        public override AppiumDriver<IWebElement> Driver { get; }
    }
}
