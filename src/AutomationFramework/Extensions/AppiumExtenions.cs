using Appium.Interfaces.Generic.SearchContext;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Mjcheetham.AppiumTesting.Automation
{
    public static class AppiumExtenions
    {
        private static readonly TimeSpan DefaultElementWaitTimeout = TimeSpan.FromMilliseconds(15000);
        private static readonly TimeSpan DefaultElementPollingInterval = TimeSpan.FromMilliseconds(1000);

        public static IWebElement WaitForElement(this ISearchContext appiumSearchContext, By by)
        {
            return WaitForElement(appiumSearchContext, by, DefaultElementWaitTimeout, DefaultElementPollingInterval);
        }

        public static IWebElement WaitForElement(this ISearchContext appiumSearchContext, By by, TimeSpan timeout, TimeSpan pollingInterval)
        {
            if (appiumSearchContext == null)
            {
                throw new ArgumentNullException(nameof(appiumSearchContext));
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
                    return appiumSearchContext.FindElement(by);
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
