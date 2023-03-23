// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;
using MoMo.NET.Models.Collections;
using MoMo.NET.Models.ExternalCollections;

namespace MoMo.NET.Tests.Unit.Foundations.Collections
{
    public partial class CollectionServiceTests
    {

        [Fact]
        public async Task ShouldPromptOAuthForCollectionAsync()
        {
             // given
            dynamic randomRecoveryProperties = CreateRandomCollectionProperties();
        
            var randomOAuthResponse = new OAuthResponse
            {
                AccessToken = randomRecoveryProperties.AccessToken,
                TokenType = randomRecoveryProperties.TokenType,
                ExpiresIn = randomRecoveryProperties.ExpiresIn,
                ExpiresAt = randomRecoveryProperties.ExpiresAt,
            };
            Collection randomRecovery = new Collection
            {
                OAuthRespose = randomOAuthResponse
            };

            var externalOAuthResponse = new ExternalOAuthResponse
            {
                AccessToken = randomRecoveryProperties.AccessToken,
                TokenType = randomRecoveryProperties.TokenType,
                ExpiresIn = randomRecoveryProperties.ExpiresIn
            };

            Collection expectedRecovery = randomRecovery.DeepClone();
            expectedRecovery.OAuthRespose = randomOAuthResponse;
            
            ExternalOAuthResponse returnedExternalOAuthResponse = 
                externalOAuthResponse;

            this.mtnBrokerMock.Setup(broker =>
                broker.GenenerateOAuthTokenAsync())
                        .ReturnsAsync(returnedExternalOAuthResponse);
            
             // when
            Collection actualRecovery =
                await this.recoveryService.RequestAuthAsync();

            // then
            actualRecovery.Should().BeEquivalentTo(expectedRecovery);

            this.mtnBrokerMock.Verify(broker =>
                broker.GenenerateOAuthTokenAsync(),
                        Times.Once);

            this.mtnBrokerMock.VerifyNoOtherCalls();
        }

    }
}

/* [Fact]
        public async Task ShouldPromptOAuthAsync()
        {
            // given
            dynamic randomRecoveryProperties = CreateRandomRecoveryProperties();
        
            var randomOAuthResponse = new OAuthResponse
            {
                AccessToken = randomRecoveryProperties.AccessToken,
                TokenType = randomRecoveryProperties.TokenType,
                ExpiresIn = randomRecoveryProperties.ExpiresIn,
                ExpiresAt = randomRecoveryProperties.ExpiresAt,
            };

            var randomRecoveryRequest = new RecoveryRequest
            {
                Amount = randomRecoveryProperties.Amount,
                Currency = randomRecoveryProperties.Currency,
                TransactionId = randomRecoveryProperties.TransactionId,
                MobileNumber = randomRecoveryProperties.MobileNumber,
                Memo = randomRecoveryProperties.Memo,
                PayeeMessage = randomRecoveryProperties.PayeeMessage
            };

            var randomAccountBalanceResponse = new AccountBalanceResponse
            {
                AvailableBalance = randomRecoveryProperties.AvailableBalance
            };

            Recovery randomRecovery = new Recovery
            {
                RecoveryRequest = randomRecoveryRequest,
                OAuthRespose = randomOAuthResponse,
                AccountBalanceResponse = randomAccountBalanceResponse
            };
            
            var externalPaymentRequest = new ExternalPaymentRequest
            {
                Amount = randomRecoveryProperties.Amount,
                Currency = randomRecoveryProperties.Currency,
                ExternalId = randomRecoveryProperties.TransactionId,
                Payer = new ExternalPayer
                {
                    PartyIdType = "MSISDN",
                    PartyId = randomRecoveryProperties.MobileNumber
                },
                PayerMessage = randomRecoveryProperties.Memo,
                PayeeNote = randomRecoveryProperties.PayeeMessage
            };

            var externalAccountBalanceResponse = new ExternalAccountBalanceResponse
            {
                AvailableBalance = randomRecoveryProperties.AvailableBalance,
                Currency = randomRecoveryProperties.Currency
            };

            var externalOAuthResponse = new ExternalOAuthResponse
            {
                AccessToken = randomRecoveryProperties.AccessToken,
                TokenType = randomRecoveryProperties.TokenType,
                ExpiresIn = randomRecoveryProperties.ExpiresIn
            };

            Recovery inputRecovery = randomRecovery;
            ExternalPaymentRequest mappedExternalPaymentRequest = externalPaymentRequest;

            ExternalAccountBalanceResponse returnedExternalAccountBalanceResponse = externalAccountBalanceResponse;
            ExternalOAuthResponse returnedExternalOAuthResponse = externalOAuthResponse;

            
            this.mtnBrokerMock.Setup(broker =>
                broker.GenenerateOAuthTokenAsync())
                        .ReturnsAsync(returnedExternalOAuthResponse);

    
            //when

            //then
        }
        */