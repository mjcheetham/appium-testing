using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace Mjcheetham.AppiumTesting.Automation
{
    public static class AppiumDriverExtenions
    {
        private static readonly TimeSpan DefaultElementWaitTimeout = TimeSpan.FromMilliseconds(15000);
        private static readonly TimeSpan DefaultElementPollingInterval = TimeSpan.FromMilliseconds(1000);

        public static W WaitForElement<W>(this AppiumDriver<W> appiumDriver, By by)
            where W : IWebElement
        {
            return WaitForElement(appiumDriver, by, DefaultElementWaitTimeout, DefaultElementPollingInterval);
        }

        public static W WaitForElement<W>(this AppiumDriver<W> appiumDriver, By by, TimeSpan timeout, TimeSpan pollingInterval)
            where W : IWebElement
        {
            if (appiumDriver == null)
            {
                throw new ArgumentNullException(nameof(appiumDriver));
            }

            if (by == null)
            {
                throw new ArgumentNullException(nameof(by));
            }

            TimeSpan totalTime = DefaultElementWaitTimeout;
            while (totalTime.TotalMilliseconds > 0)
            {
                try
                {
                    return appiumDriver.FindElement(by);
                }
                catch (Exception)
                {
                    Thread.Sleep(DefaultElementPollingInterval);
                    totalTime -= DefaultElementPollingInterval;
                }
            }

            throw new NoSuchElementException("Unable to find element: " + by);
        }
    }
}
