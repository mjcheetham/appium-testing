using Mjcheetham.AppiumTesting.AppModel.Windows;
using Mjcheetham.AppiumTesting.Configuration;
using System;

namespace Mjcheetham.AppiumTesting.Calculator.Windows
{
    public class UwpCalculatorApp : UwpApp, ICalculatorApp
    {
        private const string StandardModeMenuLabel = "Standard Calculator";
        private const string StandardModeHeaderLabel = "STANDARD Calculator mode";
        private const string ScientificModeMenuLabel = "Scientific Calculator";
        private const string ScientificModeHeaderLabel = "SCIENTITIC Calculator mode";

        public UwpCalculatorApp(IConfiguration config) : base(config)
        {
            this.StandardPage = new UwpCalculatorStandardPage(this);
        }

        #region ICalculatorApp

        public ICalculatorStandardPage StandardPage { get; }

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
    }
}
