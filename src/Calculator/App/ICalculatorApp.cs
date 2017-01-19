using Mjcheetham.AppiumTesting.AppModel;

namespace Mjcheetham.AppiumTesting.Calculator
{
    public interface ICalculatorApp : IApp
    {
        ICalculatorStandardPage StandardPage { get; }

        void PressAppMenuButton();

        CalculatorMode GetCurrentMode();

        void SwitchMode(CalculatorMode mode);
    }
}
