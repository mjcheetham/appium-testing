using Mjcheetham.AppiumTesting.Calculator.Android;
using Mjcheetham.AppiumTesting.Calculator.iOS;
using Mjcheetham.AppiumTesting.Calculator.Windows;
using Mjcheetham.AppiumTesting.Configuration;
using System;

namespace Mjcheetham.AppiumTesting.Calculator
{
    public class CalculatorAppBuilder
    {
        public ICalculatorApp Build(DeviceConfiguration config)
        {
            switch (config.PlatformType)
            {
                case PlatformType.Android:
                    return new AndroidCalculatorApp(config);
                case PlatformType.Ios:
                    return new IosCalculatorApp(config);
                case PlatformType.Windows:
                    return new UwpCalculatorApp(config);
                default:
                    throw new InvalidOperationException($"Unsupported platform type '{config.PlatformType}'");
            }
        }
    }
}
