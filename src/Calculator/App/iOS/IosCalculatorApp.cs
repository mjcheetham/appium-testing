using Mjcheetham.AppiumTesting.AppModel.iOS;
using Mjcheetham.AppiumTesting.Configuration;
using System;

namespace Mjcheetham.AppiumTesting.Calculator.iOS
{
    public class IosCalculatorApp : IosApp, ICalculatorApp
    {
        public IosCalculatorApp(IConfiguration config) : base(config)
        {
            this.StandardPage = new IosCalculatorStandardPage(this);
        }

        #region ICalculatorApp

        public ICalculatorStandardPage StandardPage { get; }

        public CalculatorMode GetCurrentMode()
        {
            throw new NotImplementedException();
        }

        public void PressAppMenuButton()
        {
            throw new NotImplementedException();
        }

        public void SwitchMode(CalculatorMode mode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
