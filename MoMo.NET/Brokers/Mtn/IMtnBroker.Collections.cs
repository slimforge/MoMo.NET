// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using MoMo.NET.Models.ExternalRecoveries;
using System.Threading.Tasks;

namespace MoMo.NET.Brokers.Mtn
{
    internal partial interface IMtnBroker
    {
        ValueTask<ExternalOAuthResponse> GenenerateOAuthTokenAsync();
        ValueTask<ExternalAccountBalanceResponse> GetAccountBalanceAsync();
        ValueTask<ExternalUserInfoResponse> GetUserInformationAsync(string accountHolderMSISDN);
        ValueTask<string> PostPaymentRequestAsync(ExternalPaymentRequest requestToPayRequest);
    }
}