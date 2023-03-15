    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

namespace MtnMoMo.NET.Models.ExternalProducts
{
    public partial class AuthTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
        public DateTime ExpiresAt { get; set; }

        public bool IsValidAndNotExpiring
        {
            get
            {
            return !String.IsNullOrEmpty(this.AccessToken) && (this.ExpiresAt > DateTime.UtcNow.AddSeconds(30));
            }
        }
    }
}
