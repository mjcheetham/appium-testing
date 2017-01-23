using System;
using System.Collections.Generic;
using System.Linq;

namespace Mjcheetham.AppiumTesting.Calculator
{
    public static class CalculatorStandardPageExtensions
    {
        public static void EnterNumber(this ICalculatorStandardPage page, int number)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            IEnumerable<int> digits = Math.Abs(number).ToString().Select(DigitCharToInt);
            EnterDigitSequence(page, digits);

            if (number < 0)
            {
                page.PressPlusMinus();
            }
        }

        public static void EnterNumber(this ICalculatorStandardPage page, double number)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            page.EnterNumber((decimal)number);
        }

        public static void EnterNumber(this ICalculatorStandardPage page, decimal number)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            string[] partsStr = Math.Abs(number).ToString().Split('.').ToArray();
            IEnumerable<int> firstDigits = partsStr[0].Select(DigitCharToInt);
            IEnumerable<int> secondDigits = partsStr[1].Select(DigitCharToInt);

            EnterDigitSequence(page, firstDigits);
            page.PressDecimal();
            EnterDigitSequence(page, secondDigits);

            if (number < 0)
            {
                page.PressPlusMinus();
            }
        }


        #region Helpers

        private static int DigitCharToInt(char digit)
        {
            return Convert.ToInt32(digit) - 48;
        }

        private static void EnterDigitSequence(ICalculatorStandardPage page, IEnumerable<int> digits)
        {
            foreach (int digit in digits)
            {
                page.EnterDigit(digit);
            }
        }

        #endregion
    }
}
