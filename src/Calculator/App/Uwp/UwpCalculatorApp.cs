using Mjcheetham.AppiumTesting.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace Mjcheetham.AppiumTesting.Calculator.Uwp
{
    public class UwpCalculatorApp : ICalculatorApp
    {
        private const string StandardModeMenuLabel = "Standard Calculator";
        private const string StandardModeHeaderLabel = "STANDARD Calculator mode";
        private const string ScientificModeMenuLabel = "Scientific Calculator";
        private const string ScientificModeHeaderLabel = "SCIENTITIC Calculator mode";

        private readonly UwpCalculatorStandardPage standardPage;

        public UwpCalculatorApp(DeviceConfiguration config)
        {
            this.Driver = new WindowsDriver<IWebElement>(config.AutomationServerUrl, config.DesiredCapabilties(), config.CommandTimeout);
            this.Driver.Manage().Timeouts().ImplicitlyWait(config.ElementSearchTimeout);

            this.standardPage = new UwpCalculatorStandardPage(this);
        }

        #region ICalculatorApp

        public AppiumDriver<IWebElement> Driver { get; }

        public ICalculatorStandardPage StandardPage => this.standardPage;

        public void PressAppMenuButton()
        {
            this.Driver.FindElementByAccessibilityId("NavButton").Click();
        }

        public CalculatorMode GetCurrentMode()
        {
            CalculatorMode currentMode;
            string modeText = this.Driver.FindElementByAccessibilityId("Header").Text;
            switch (modeText)
            {
                case StandardModeHeaderLabel:
                    currentMode = CalculatorMode.Standard;
                    break;
                case ScientificModeHeaderLabel:
                    currentMode = CalculatorMode.Scientific;
                    break;
                default:
                    throw new InvalidOperationException("Application is in unknown mode");
            }

            return currentMode;
        }

        public void SwitchMode(CalculatorMode mode)
        {
            this.PressAppMenuButton();

            string buttonLabel;
            switch (mode)
            {
                case CalculatorMode.Standard:
                    buttonLabel = StandardModeMenuLabel;
                    break;
                case CalculatorMode.Scientific:
                    buttonLabel = ScientificModeMenuLabel;
                    break;
                default:
                    throw new ArgumentException("Unknown mode");
            }
            this.Driver.FindElementByXPath($"//ListItem[@Name=\"{buttonLabel}\"]").Click();
        }

        #endregion

        #region IDisposable

        private bool isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    this.Driver?.Close();
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
