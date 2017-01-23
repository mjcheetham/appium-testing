using Mjcheetham.AppiumTesting.Configuration;
using System;
using Xunit;

namespace Mjcheetham.AppiumTesting.Calculator.Tests
{
    public class CalculatorTests : IClassFixture<CalculatorAppBuilder>, IDisposable
    {
        private readonly ICalculatorApp app;
        private readonly ISecretProvider secretProvider;

        public CalculatorTests(CalculatorAppBuilder appBuilder)
        {
            var vaultUrl = new Uri("https://mjcheetham-appiumtest-kv.vault.azure.net/");
            string clientId = "4307c2fe-19d5-4c77-bdfd-cc47c29996eb";
            string authCertThumbprint = "3f2a039a4bc39310d6aea920fb46839003517cdf";

            var certProvider = new LocalCertificateProvider();
            var authCertificate = certProvider.FindCertificateByThumbprint(authCertThumbprint);
            this.secretProvider = new AzureKeyVaultSecretProvider(vaultUrl, clientId, authCertificate);

            this.app = appBuilder.AddJsonConfiguration("config.windows.json")
                                 .Build();

            if (this.app.GetCurrentMode() != CalculatorMode.Standard)
            {
                this.app.SwitchMode(CalculatorMode.Standard);
            }
        }

        [Fact(DisplayName = nameof(AddSecretNumbers))]
        public void AddSecretNumbers()
        {
            int secretNumber1 = this.secretProvider.GetSecret<int>("testsecret1");
            int secretNumber2 = this.secretProvider.GetSecret<int>("testsecret2");
            int secretNumber3 = this.secretProvider.GetSecret<int>("testsecret3");

            this.app.StandardPage.EnterNumber(secretNumber1);
            this.app.StandardPage.PressPlus();
            this.app.StandardPage.EnterNumber(secretNumber2);
            this.app.StandardPage.PressEquals();
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(secretNumber3, result);
        }

        [Fact(DisplayName = nameof(Addition))]
        public void Addition()
        {
            this.app.StandardPage.EnterDigit(7);
            this.app.StandardPage.PressPlus();
            this.app.StandardPage.EnterDigit(3);
            this.app.StandardPage.PressEquals();
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(10, result);
        }

        [Fact(DisplayName = nameof(Addition_Decimal))]
        public void Addition_Decimal()
        {
            this.app.StandardPage.EnterNumber(3.14);
            this.app.StandardPage.PressPlus();
            this.app.StandardPage.EnterNumber(3.14);
            this.app.StandardPage.PressEquals();
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(6.28m, result, 2);
        }

        [Theory(DisplayName = nameof(Subtraction))]
        [InlineData(5, 4, 1)]
        [InlineData(8, 8, 0)]
        [InlineData(8, 10, -2)]
        public void Subtraction(int a, int b, int answer)
        {
            this.app.StandardPage.EnterNumber(a);
            this.app.StandardPage.PressSubtract();
            this.app.StandardPage.EnterNumber(b);
            this.app.StandardPage.PressEquals();
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(answer, result, 0);
        }


        [Fact(DisplayName = nameof(Backspace))]
        public void Backspace()
        {
            this.app.StandardPage.EnterDigit(1);
            this.app.StandardPage.EnterDigit(2);
            this.app.StandardPage.EnterDigit(3);
            this.app.StandardPage.PressBackspace();
            this.app.StandardPage.EnterDigit(4);
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(124, result);
        }

        #region IDisposable

        private bool isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this.app?.Dispose();
                }

                this.isDisposed = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
