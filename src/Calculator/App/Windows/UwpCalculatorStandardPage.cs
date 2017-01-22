using Mjcheetham.AppiumTesting.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mjcheetham.AppiumTesting.Calculator.Windows
{
    public class UwpCalculatorStandardPage : Page<UwpCalculatorApp>, ICalculatorStandardPage
    {
        public UwpCalculatorStandardPage(UwpCalculatorApp app) : base(app) { }

        #region ICalculatorStandardPage

        public void PressPlus()
        {
            this.App.Driver.FindElementByAccessibilityId("plusButton").Click();
        }

        public void PressSubtract()
        {
            this.App.Driver.FindElementByAccessibilityId("minusButton").Click();
        }

        public void PressMultiply()
        {
            this.App.Driver.FindElementByAccessibilityId("multiplyButton").Click();
        }

        public void PressDivide()
        {
            this.App.Driver.FindElementByAccessibilityId("divideButton").Click();
        }

        public void PressBackspace()
        {
            this.App.Driver.FindElementByAccessibilityId("backSpaceButton").Click();
        }

        public void PressClear()
        {
            this.App.Driver.FindElementByAccessibilityId("clearButton").Click();
        }

        public void PressClearEntry()
        {
            this.App.Driver.FindElementByAccessibilityId("clearEntryButton").Click();
        }

        public void PressEquals()
        {
            this.App.Driver.FindElementByAccessibilityId("equalButton").Click();
        }

        public void PressPlusMinus()
        {
            this.App.Driver.FindElementByAccessibilityId("negateButton").Click();
        }

        public void PressDecimal()
        {
            this.App.Driver.FindElementByAccessibilityId("decimalSeparatorButton").Click();
        }

        public void EnterDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new NotImplementedException($"'{digit}' is not a digit.");
            }

            var id = $"num{digit}Button";
            this.App.Driver.FindElementByAccessibilityId(id).Click();
        }

        public void EnterNumber(int number)
        {
            IEnumerable<int> digits = Math.Abs(number).ToString().Select(DigitCharToInt);
            this.EnterDigitSequence(digits);

            if (number < 0)
            {
                this.PressPlusMinus();
            }
        }

        public void EnterNumber(double number)
        {
            EnterNumber((decimal)number);
        }

        public void EnterNumber(decimal number)
        {
            string[] partsStr = Math.Abs(number).ToString().Split('.').ToArray();
            IEnumerable<int> firstDigits = partsStr[0].Select(DigitCharToInt);
            IEnumerable<int> secondDigits = partsStr[1].Select(DigitCharToInt);

            this.EnterDigitSequence(firstDigits);
            this.PressDecimal();
            this.EnterDigitSequence(secondDigits);

            if (number < 0)
            {
                this.PressPlusMinus();
            }
        }

        public decimal GetResult()
        {
            string displayText = this.GetDisplayString();
            Match match = Regex.Match(displayText, @"Display is\s+(?'value'.+)\s", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string numStr = match.Groups["value"].Value;
                decimal number;
                if (decimal.TryParse(numStr, out number))
                {
                    return number;
                }
            }

            throw new InvalidOperationException("Display is not a numeric value");
        }

        public string GetDisplayString()
        {
            return this.App.Driver.FindElementByAccessibilityId("CalculatorResults").Text;
        }

        #endregion

        #region Helpers

        private static int DigitCharToInt(char digit)
        {
            return Convert.ToInt32(digit) - 48;
        }

        private void EnterDigitSequence(IEnumerable<int> digits)
        {
            foreach (int digit in digits)
            {
                this.EnterDigit(digit);
            }
        }

        #endregion
    }
}
