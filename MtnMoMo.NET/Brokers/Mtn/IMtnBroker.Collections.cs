// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using MtnMoMo.NET.Models.ExternalCollections;
using System.Threading.Tasks;

namespace MtnMoMo.NET.Brokers.Mtn
{
    internal partial interface IMtnBroker
    {
        ValueTask<AuthTokenResponse> GenenerateCollectionsAuthTokenAsync();
        ValueTask<AccountBalanceResponse> GetAccountBalanceAsync();
        ValueTask<UserInfoResponse> GetUserInformationAsync(string accountHolderMSISDN);
        ValueTask<string> PostRequestToPayAsync(RequestToPayRequest requestToPayRequest);
    }
}