// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace MtnMoMo.NET.Models.ExternalCollections
{
    public partial class AccountBalanceResponse
    {
        [JsonProperty("availableBalance")]
        public string AvailableBalance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
