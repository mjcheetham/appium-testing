using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;

namespace Mjcheetham.AppiumTesting.AppModel
{
    public abstract class App : IApp
    {
        #region IApp

        public abstract AppiumDriver<IWebElement> Driver { get; }

        #endregion

        #region IDisposable

        private bool isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    this.Driver?.Quit();
                }

                this.isDisposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
