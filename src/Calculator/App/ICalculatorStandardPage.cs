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

        void EnterNumber(int number);

        void EnterNumber(double number);

        void EnterNumber(decimal number);

        decimal GetResult();

        string GetDisplayString();
    }
}
