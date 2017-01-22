using Mjcheetham.AppiumTesting.AppModel.Android;
using Mjcheetham.AppiumTesting.Configuration;
using System;

namespace Mjcheetham.AppiumTesting.Calculator.Android
{
    public class AndroidCalculatorApp : AndroidApp, ICalculatorApp
    {
        public AndroidCalculatorApp(DeviceConfiguration config) : base(config)
        {
            this.StandardPage = new AndroidCalculatorStandardPage(this);
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
