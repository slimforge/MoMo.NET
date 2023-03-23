// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using Newtonsoft.Json;

namespace MoMo.NET.Models.ExternalCollections
{
    internal class ExternalCollectionRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; } = 0;

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("externalId")]
        public string ExternalId { get; set; } = string.Empty;

        [JsonProperty("payer")]
        public ExternalPayer Payer { get; set; }

        [JsonProperty("payerMessage")]
        public string PayerMessage { get; set; }

        [JsonProperty("payeeNote")]
        public string PayeeNote { get; set; } = string.Empty;
    }

    internal class ExternalPayer
    {
        [JsonProperty("partyIdType")]
        public string PartyIdType { get; set; } = string.Empty;

        [JsonProperty("partyId")]
        public string PartyId { get; set; } = string.Empty;
    }
}
/*
var jsonRTP = new TransientRequest {
                                externalId = correlationId,
                                amount = amount,
                                currency = "EUR",
                                payerMessage = "This Month",
                                payeeNote = remarks,
                                payer = new Payer {
                                partyIdType = "MSISDN",
                                partyId = msidn
                                }
*/