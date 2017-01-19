using OpenQA.Selenium.Remote;
using System;

namespace Mjcheetham.AppiumTesting.Automation
{
    public class CalculatorTestContext
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";

        public RemoteWebDriver Session { get; }

        public CalculatorTestContext()
        {
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");

            Session = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        }
    }
}
