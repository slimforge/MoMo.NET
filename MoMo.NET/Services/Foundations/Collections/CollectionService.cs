// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Threading.Tasks;
using MoMo.NET.Brokers.Mtn;
using MoMo.NET.Models.Collections;

namespace MoMo.NET.Services.Foundations.Collections
{
    internal partial class CollectionService : ICollectionService
    {
        private readonly IMtnBroker mtnBroker;

        public CollectionService(IMtnBroker mtnBroker) =>
            this.mtnBroker = mtnBroker;

        public ValueTask<Collection> AuthenticateClientAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Collection> PromptRecoveryAsync(Collection recoveryRequest)
        {
            throw new NotImplementedException();
        }
    }
}