using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using Xunit;

namespace Mjcheetham.AppiumTesting.Automation
{
    public class CalculatorTests : IClassFixture<CalculatorTestContext>
    {
        private readonly CalculatorTestContext context;

        public CalculatorTests(CalculatorTestContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        [Fact]
        public void Seven()
        {
            IWebElement sevenButton = context.Session.WaitForElement(By.Name("Seven"));
            IWebElement addButton = context.Session.WaitForElement(By.Name("Plus"));
            IWebElement threeButton = context.Session.WaitForElement(By.Name("Three"));

            sevenButton.Click();
            addButton.Click();
            threeButton.Click();
            context.Session.Keyboard.SendKeys(Keys.Enter);

            string screenshotFilePath = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N")), "png");
            context.Session.GetScreenshot().SaveAsFile(screenshotFilePath, ImageFormat.Png);

            Size originalSize = context.Session.Manage().Window.Size;
            context.Session.Manage().Window.Maximize();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            context.Session.Manage().Window.Size = originalSize;

            Process.Start(new ProcessStartInfo(screenshotFilePath) { UseShellExecute = true });
        }
    }
}
