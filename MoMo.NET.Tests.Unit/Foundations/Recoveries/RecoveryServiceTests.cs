// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
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
    }
}