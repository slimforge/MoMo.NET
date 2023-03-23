// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Moq;
using Xunit;
using KellermanSoftware.CompareNetObjects;
using System.Linq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;
using MoMo.NET.Models.Collections;
using MoMo.NET.Models.ExternalCollections;
using MoMo.NET.Brokers.Mtn;
using MoMo.NET.Services.Foundations.Collections;

namespace MoMo.NET.Tests.Unit.Foundations.Collections
{
    public partial class CollectionServiceTests
    {
        private readonly Mock<IMtnBroker> mtnBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ICollectionService recoveryService;

        public CollectionServiceTests() 
        {
            this.mtnBrokerMock = new Mock<IMtnBroker>();
            this.compareLogic = new CompareLogic();
            this.recoveryService = new CollectionService(
                mtnBroker: this.mtnBrokerMock.Object);
        } 

        public static TheoryData UnAuthorizationExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }

        private Expression<Func<ExternalPaymentRequest, bool>> SameExternalPaymentRequestAs(
            ExternalPaymentRequest expectedExternalPaymentRequest)
        {
            return actualExternalPaymentRequest =>
                this.compareLogic.Compare(expectedExternalPaymentRequest, actualExternalPaymentRequest)
                    .AreEqual;
        }

        private static dynamic CreateRandomCollectionProperties()
        {
                return new
                {
                    AccessToken = CreateRandomString(),
                    TokenType = CreateRandomString(),
                    ExpiresIn = GetRandomNumber(),
                    ExpiresAt = GenerateRandomDate(),
                    Amount = GetRandomNumber(),
                    Currency = "EUR",
                    TransactionId = CreateRandomGuid(),
                    MobileNumber = CreateRandomString(),
                    Memo = CreateRandomString(),
                    PayeeMessage = CreateRandomString(),
                    AvailableBalance = GetRandomNumber()
                };

        }

        private static string CreateRandomGuid() =>
            new Guid().ToString();
        private static DateTime GenerateRandomDate()=>
            new SequenceGeneratorDateTime().GetValue();

        private static int GetRandomNumber()=>
            new IntRange(min: 0, max: 10000).GetValue();
        private static string CreateRandomString() =>
            new MnemonicString().GetValue();
        private static Collection CreateRandomRecovery() =>
            CreateRecoveryFiller().Create();
        private static Filler<Collection> CreateRecoveryFiller()
        {
            var filler = new Filler<Collection>();

            filler.Setup()
                .OnType<object>().IgnoreIt();

            return filler;
        }



    }
}