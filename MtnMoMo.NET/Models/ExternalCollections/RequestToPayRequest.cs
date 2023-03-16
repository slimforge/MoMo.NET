// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using Newtonsoft.Json;

namespace MtnMoMo.NET.Models.ExternalCollections
{
    public partial class RequestToPayRequest
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("payer")]
        public Payer Payer { get; set; }

        [JsonProperty("payerMessage")]
        public string PayerMessage { get; set; }

        [JsonProperty("payeeNote")]
        public string PayeeNote { get; set; }
    }

    public partial class Payer
    {
        [JsonProperty("partyIdType")]
        public string PartyIdType { get; set; }

        [JsonProperty("partyId")]
        public string PartyId { get; set; }
    }
}
