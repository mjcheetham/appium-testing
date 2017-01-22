using Mjcheetham.AppiumTesting.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Mjcheetham.AppiumTesting.AppModel.Windows
{
    public abstract class UwpApp : App
    {
        public UwpApp(DeviceConfiguration config)
        {
            this.Driver = new WindowsDriver<IWebElement>(config.AutomationServerUrl, config.DesiredCapabilties(), config.CommandTimeout);
            this.Driver.Manage().Timeouts().ImplicitlyWait(config.ElementSearchTimeout);
        }

        public override AppiumDriver<IWebElement> Driver { get; }
    }
}
