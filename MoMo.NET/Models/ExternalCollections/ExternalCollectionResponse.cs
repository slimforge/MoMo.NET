// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace MoMo.NET.Models.ExternalCollections
{
    internal class ExternalCollectionResponse
    {
        [JsonProperty("repsonseCode")]
        public string ResponseCode { get; set; }

    }
}
