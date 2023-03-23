// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace MoMo.NET.Models.ExternalCollections
{
    internal class ExternalAccountBalanceResponse
    {
        [JsonProperty("availableBalance")]
        public string AvailableBalance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
