// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// -----

namespace MoMo.NET.Models.Collections
{
    public class CollectionRequest
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
        //public string MobileNumber { get; set; }
        public string Memo { get; set; }
        public string PayeeMessage { get; set; }
        public Payer Payer { get; set; }
    }
}