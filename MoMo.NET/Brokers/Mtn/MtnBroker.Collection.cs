// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using MoMo.NET.Models.ExternalCollections;
using System.Threading.Tasks;

namespace MoMo.NET.Brokers.Mtn
{
    internal partial class MtnBroker
    {
        public async ValueTask<ExternalOAuthResponse> GenenerateOAuthTokenAsync() =>
            await PostAsyncForAuth<string, ExternalOAuthResponse>(relativeUrl: "collection/token/", null);

        public async ValueTask<ExternalAccountBalanceResponse> GetAccountBalanceAsync() =>
            await GetAsync<ExternalAccountBalanceResponse>(relativeUrl: "collection/v1_0/account/balance");

        public async ValueTask<ExternalUserInfoResponse> GetUserInformationAsync(string accountHolderMSISDN) =>
            await GetAsync<ExternalUserInfoResponse>(relativeUrl: string.Format("collection/v1_0/accountholder/msisdn/{0}/basicuserinfo", accountHolderMSISDN));
        public async ValueTask<ExternalCollectionResponse> PostPaymentRequestAsync(ExternalCollectionRequest requestToPayRequest) =>
            await PostAsync<ExternalCollectionRequest, ExternalCollectionResponse>(relativeUrl: "collection/v1_0/requesttopay", 
                requestToPayRequest);

    }
}