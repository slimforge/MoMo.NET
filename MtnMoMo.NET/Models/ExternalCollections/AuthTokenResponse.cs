// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace MtnMoMo.NET.Models.ExternalCollections
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
