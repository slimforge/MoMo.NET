// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using MoMo.NET.Models.Recoveries;
using MoMo.NET.Brokers.Mtn;
using MoMo.NET.Services.Foundations.Recoveries;

namespace MoMo.NET.Tests.Unit.Foundations.Recoveries
{
    public partial class RecoveryServiceTests
    {
        private readonly Mock<IMtnBroker> mtnBrokerMock;
        private readonly IRecoveryService recoveryService;

        public RecoveryServiceTests() 
        {
            this.mtnBrokerMock = new Mock<IMtnBroker>();
            this.recoveryService = new RecoveryService(
                mtnBroker: this.mtnBrokerMock.Object);
        } 

        private static dynamic CreateRandomRecoveryProperties()
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

        private static Guid CreateRandomGuid() =>
            new Guid();
        private static DateTime GenerateRandomDate()=>
            new SequenceGeneratorDateTime().GetValue();

        private static int GetRandomNumber()=>
            new IntRange(min: 0, max: 10000).GetValue();
        private static string CreateRandomString() =>
            new MnemonicString().GetValue();
        private static Recovery CreateRandomRecovery() =>
            CreateRecoveryFiller().Create();
        private static Filler<Recovery> CreateRecoveryFiller()=>
            new Filler<Recovery>();



    }
}