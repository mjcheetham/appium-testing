﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mjcheetham.AppiumTesting.Configuration
{
    [JsonObject(MemberSerialization.Fields)]
    public class DeviceConfiguration
    {
        #region JSON fields

        [JsonProperty("automationServerUrl")]
        private string automationServerUrl;

        [JsonProperty("capabilities")]
        private Dictionary<string, string> capabilities;

        [JsonProperty("commandtimeout")]
        private int? commandTimeout;

        [JsonProperty("elementSearchTimeout")]
        private int? elementSearchTimeout;

        #endregion

        public Uri AutomationServerUrl
        {
            get
            {
                Uri uri;
                return Uri.TryCreate(this.automationServerUrl, UriKind.Absolute, out uri)
                    ? uri
                    : null;
            }
        }

        public IReadOnlyDictionary<string, string> Capabilities => new ReadOnlyDictionary<string, string>(this.capabilities);

        public TimeSpan CommandTimeout
        {
            get
            {
                return this.commandTimeout.HasValue
                    ? TimeSpan.FromMilliseconds(this.commandTimeout.Value)
                    : TimeSpan.Zero;
            }
        }

        public TimeSpan ElementSearchTimeout
        {
            get
            {
                return this.elementSearchTimeout.HasValue
                    ? TimeSpan.FromMilliseconds(this.elementSearchTimeout.Value)
                    : TimeSpan.Zero;
            }
        }
    }
}