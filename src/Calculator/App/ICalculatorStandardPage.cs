namespace Mjcheetham.AppiumTesting.Calculator
{
    public interface ICalculatorStandardPage
    {
        void PressPlus();

        void PressSubtract();

        void PressMultiply();

        void PressDivide();

        void PressClear();

        void PressClearEntry();

        void PressBackspace();

        void PressEquals();

        void PressPlusMinus();

        void PressDecimal();

        void EnterDigit(int digit);

        decimal GetResult();

        string GetDisplayString();
    }
}
