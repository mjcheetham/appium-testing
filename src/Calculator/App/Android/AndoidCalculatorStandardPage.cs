using Mjcheetham.AppiumTesting.AppModel;
using OpenQA.Selenium.Appium.Android;
using System;

namespace Mjcheetham.AppiumTesting.Calculator.Android
{
    internal class AndroidCalculatorStandardPage : Page<AndroidCalculatorApp>, ICalculatorStandardPage
    {
        public AndroidCalculatorStandardPage(AndroidCalculatorApp app) : base(app) { }

        #region ICalculatorStandardPage

        public void EnterDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new NotImplementedException($"'{digit}' is not a digit.");
            }

            this.App.Driver.FindElementByXPath($"//android.widget.Button[@text=\"{digit}\"]").Click();
        }

        public string GetDisplayString()
        {
            return this.App.Driver.FindElementById("com.android.calculator2:id/formula").Text;
        }

        public decimal GetResult()
        {
            string displayText = this.GetDisplayString();
            decimal number;
            if (decimal.TryParse(displayText, out number))
            {
                return number;
            }

            throw new InvalidOperationException("Display is not a numeric value");
        }

        public void PressBackspace()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"del\"]").Click();
        }

        public void PressClear()
        {
            AndroidElement el =(AndroidElement)this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"del\"]");
            el.Tap(1, 5);
        }

        public void PressClearEntry()
        {
            throw new NotImplementedException();
        }

        public void PressDecimal()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\".\"]").Click();
        }

        public void PressDivide()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"÷\"]").Click();
        }

        public void PressEquals()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"=\"]").Click();
        }

        public void PressMultiply()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"×\"]").Click();
        }

        public void PressPlus()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"+\"]").Click();
        }

        public void PressPlusMinus()
        {
            throw new NotImplementedException();
        }

        public void PressSubtract()
        {
            this.App.Driver.FindElementByXPath("//android.widget.Button[@text=\"−\"]").Click();
        }

        #endregion
    }
}