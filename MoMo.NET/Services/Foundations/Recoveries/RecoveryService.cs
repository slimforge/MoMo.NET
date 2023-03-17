// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Threading.Tasks;
using MoMo.NET.Brokers.Mtn;
using MoMo.NET.Models.Recoveries;

namespace MoMo.NET.Services.Foundations.Recoveries
{
    internal partial class RecoveryService : IRecoveryService
    {
        private readonly IMtnBroker mtnBroker;

        public RecoveryService(IMtnBroker mtnBroker) =>
            this.mtnBroker = mtnBroker;

        public ValueTask<Recovery> AuthenticateClientAsync()
        {
            throw new NotImplementedException();
        }
    }
}