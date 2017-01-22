using Mjcheetham.AppiumTesting.Calculator.Android;
using Mjcheetham.AppiumTesting.Calculator.iOS;
using Mjcheetham.AppiumTesting.Calculator.Windows;
using Mjcheetham.AppiumTesting.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Mjcheetham.AppiumTesting.Calculator
{
    public class CalculatorAppBuilder
    {
        private IConfiguration config;

        public CalculatorAppBuilder()
        {
        }

        public CalculatorAppBuilder AddJsonConfiguration(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            string fullFilePath;
            if (Path.IsPathRooted(filePath))
            {
                fullFilePath = Path.GetFullPath(filePath);
            }
            else
            {
                fullFilePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, filePath));
            }

            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException("Cannot find configuration file", fullFilePath);
            }

            string json = File.ReadAllText(fullFilePath);
            this.config = JsonConvert.DeserializeObject<JsonConfiguration>(json);

            return this;
        }

        public CalculatorAppBuilder AddConfiguration(IConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            this.config = config;

            return this;
        }

        public ICalculatorApp Build()
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
