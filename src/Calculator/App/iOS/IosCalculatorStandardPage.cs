﻿using System;
using Mjcheetham.AppiumTesting.AppModel;

namespace Mjcheetham.AppiumTesting.Calculator.iOS
{
    internal class IosCalculatorStandardPage : Page<IosCalculatorApp>, ICalculatorStandardPage
    {
        public IosCalculatorStandardPage(IosCalculatorApp app) : base(app) { }

        #region ICalculatorStandardPage

        public void EnterDigit(int digit)
        {
            throw new NotImplementedException();
        }

        public string GetDisplayString()
        {
            throw new NotImplementedException();
        }

        public decimal GetResult()
        {
            throw new NotImplementedException();
        }

        public void PressBackspace()
        {
            throw new NotImplementedException();
        }

        public void PressClear()
        {
            throw new NotImplementedException();
        }

        public void PressClearEntry()
        {
            throw new NotImplementedException();
        }

        public void PressDecimal()
        {
            throw new NotImplementedException();
        }

        public void PressDivide()
        {
            throw new NotImplementedException();
        }

        public void PressEquals()
        {
            throw new NotImplementedException();
        }

        public void PressMultiply()
        {
            throw new NotImplementedException();
        }

        public void PressPlus()
        {
            throw new NotImplementedException();
        }

        public void PressPlusMinus()
        {
            throw new NotImplementedException();
        }

        public void PressSubtract()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}