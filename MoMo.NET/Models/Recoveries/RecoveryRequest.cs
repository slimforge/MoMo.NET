// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// -----

namespace MoMo.NET.Models.Recoveries
{
    public class RecoveryRequest
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
        public string MobileNumber { get; set; }
        public string Memo { get; set; }
        public string PayeeMessage { get; set; }
    }
}