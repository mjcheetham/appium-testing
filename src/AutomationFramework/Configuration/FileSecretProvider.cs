using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mjcheetham.AppiumTesting.Automation.Configuration
{
    class FileSecretProvider : ISecretProvider
    {
        private readonly string filePath;
        private readonly IDictionary<string, string> data;

        public FileSecretProvider(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File must exist", nameof(filePath));
            }

            this.filePath = filePath;
            this.data = ParseJson(this.filePath);
        }

        #region ISecretProvider

        public string GetSecret(string secretName)
        {
            string value;
            if (this.data.TryGetValue(secretName, out value))
            {
                return value;
            }

            return null;
        }

        #endregion

        #region Helpers

        private static IDictionary<string, string> ParseJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        #endregion
    }
}
