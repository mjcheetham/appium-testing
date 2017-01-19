using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;

namespace Mjcheetham.AppiumTesting.AppModel
{
    public interface IApp : IDisposable
    {
        AppiumDriver<IWebElement> Driver { get; }
    }
}
