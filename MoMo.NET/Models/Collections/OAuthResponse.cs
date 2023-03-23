// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// -----

using System;

namespace MoMo.NET.Models.Collections
{
    public class OAuthResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
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