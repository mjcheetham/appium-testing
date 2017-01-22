using Mjcheetham.AppiumTesting.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Mjcheetham.AppiumTesting.AppModel.Android
{
    public abstract class AndroidApp : App
    {
        public AndroidApp(IConfiguration config)
        {
            this.Driver = new AndroidDriver<IWebElement>(config.AutomationServerUrl, config.DesiredCapabilties(), config.CommandTimeout);
            this.Driver.Manage().Timeouts().ImplicitlyWait(config.ElementSearchTimeout);
        }

        public override AppiumDriver<IWebElement> Driver { get; }
    }
}
