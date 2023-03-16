// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using MtnMoMo.NET.Models.ExternalCollections;
using System.Threading.Tasks;

namespace MtnMoMo.NET.Brokers.Mtn
{
    internal partial class MtnBroker
    {
        public async ValueTask<AuthTokenResponse> GenenerateCollectionsAuthTokenAsync() =>
            await PostAsyncForAuth<string, AuthTokenResponse>(relativeUrl: "collection/token/", null);

        public async ValueTask<AccountBalanceResponse> GetAccountBalanceAsync() =>
            await GetAsync<AccountBalanceResponse>(relativeUrl: "collection/v1_0/account/balance");

        public async ValueTask<UserInfoResponse> GetUserInformationAsync(string accountHolderMSISDN) =>
            await GetAsync<UserInfoResponse>(relativeUrl: string.Format("collection/v1_0/accountholder/msisdn/{0}/basicuserinfo", accountHolderMSISDN));
        public async ValueTask<string> PostRequestToPayAsync(RequestToPayRequest requestToPayRequest) =>
            await PostAsync<RequestToPayRequest, string>(relativeUrl: "collection/v1_0/requesttopay", 
                requestToPayRequest);

    }
}