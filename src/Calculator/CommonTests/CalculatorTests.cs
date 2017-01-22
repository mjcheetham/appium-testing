using Mjcheetham.AppiumTesting.Configuration;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Mjcheetham.AppiumTesting.Calculator.Tests
{
    public class CalculatorTests : IDisposable
    {
        private readonly ICalculatorApp app;

        public CalculatorTests()
        {
            string windowsJson = @"{
    ""platform"": ""windows"",
    ""automationServerUrl"": ""http://127.0.0.1:4723/"",
    ""commandTimeout"": 60000,
    ""elementSearchTimeout"": 5000,
    ""capabilities"": {
        ""app"": ""Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"",
        ""platformName"": ""Windows"",
        ""deviceName"": ""WindowsPC"",
    }
}";
            string iosJson = @"{
    ""platform"": ""ios"",
    ""automationServerUrl"": ""http://192.168.0.24:4723/wd/hub/"",
    ""commandTimeout"": 300000,
    ""elementSearchTimeout"": 5000,
    ""capabilities"": {
        ""bundleId"": ""com.apple.calendar"",
        ""platformName"": ""iOS"",
        ""deviceName"": ""iPhone 6"",
        ""automationName"": ""XCUITest""
    }
}";
            var appBuilder = new CalculatorAppBuilder();
            DeviceConfiguration windowsConfig = JsonConvert.DeserializeObject<DeviceConfiguration>(windowsJson);
            DeviceConfiguration iosConfig = JsonConvert.DeserializeObject<DeviceConfiguration>(iosJson);

            app = appBuilder.Build(iosConfig);

            app.SwitchMode(CalculatorMode.Standard);
        }

        [Fact]
        public void Addition()
        {
            this.app.StandardPage.EnterDigit(7);
            this.app.StandardPage.PressPlus();
            this.app.StandardPage.EnterDigit(3);
            this.app.StandardPage.PressEquals();
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(10, result);
        }

        [Fact]
        public void Addition_Decimal()
        {
            this.app.StandardPage.EnterNumber(3.14);
            this.app.StandardPage.PressPlus();
            this.app.StandardPage.EnterNumber(3.14);
            this.app.StandardPage.PressEquals();
            var result = this.app.StandardPage.GetResult();
            Assert.Equal(6.28m, result, 2);
        }

        [Theory]
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


        [Fact]
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
