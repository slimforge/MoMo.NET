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
        public async Task ShouldPromptCollectionRequestAsync()
        {
             // given
            dynamic randomRecoveryProperties = CreateRandomCollectionProperties();

            var randomRecoveryRequest = new CollectionRequest
            {
                Amount = randomRecoveryProperties.Amount,
                Currency = randomRecoveryProperties.Currency,
                TransactionId = randomRecoveryProperties.TransactionId,
                MobileNumber = randomRecoveryProperties.MobileNumber,
                Memo = randomRecoveryProperties.Memo,
                PayeeMessage = randomRecoveryProperties.PayeeMessage
            };

            Collection randomRecovery = new Collection
            {
                RecoveryRequest = randomRecoveryRequest
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

            Collection inputRecovery = randomRecovery;
            Collection expectedRecovery = inputRecovery.DeepClone();
            //expectedRecovery.RecoveryRequest = externalPaymentRequest;
            
            ExternalPaymentRequest mappedExternalPaymentRequest = 
                externalPaymentRequest;

            string returnedExternalPaymentResponse = "some string";

            this.mtnBrokerMock.Setup(broker =>
                broker.PostPaymentRequestAsync(It.Is(
                    SameExternalPaymentRequestAs(mappedExternalPaymentRequest))))
                        .ReturnsAsync(returnedExternalPaymentResponse);

            // when
            Collection actualRecovery =
                await this.recoveryService.PromptRecoveryAsync(inputRecovery);

            // then
            actualRecovery.Should().BeEquivalentTo(expectedRecovery);

            this.mtnBrokerMock.Verify(broker =>
                broker.PostPaymentRequestAsync(It.Is(
                    SameExternalPaymentRequestAs(mappedExternalPaymentRequest))),
                        Times.Once);

            this.mtnBrokerMock.VerifyNoOtherCalls();

        }
    }
}