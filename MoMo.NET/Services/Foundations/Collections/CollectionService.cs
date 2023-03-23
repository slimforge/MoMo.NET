// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Threading.Tasks;
using MoMo.NET.Brokers.Mtn;
using MoMo.NET.Models.Collections;
using MoMo.NET.Models.ExternalCollections;

namespace MoMo.NET.Services.Foundations.Collections
{
    internal partial class CollectionService : ICollectionService
    {
        private readonly IMtnBroker mtnBroker;

        public CollectionService(IMtnBroker mtnBroker) =>
            this.mtnBroker = mtnBroker;

        public async ValueTask<Collection> RequestAuthAsync()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Collection> PromptCollectionRequestAsync(Collection collection)
        {
            var externalCollectionRequest = ConvertToCollectionRequest(collection);
            var collectionResponse = await this.mtnBroker.PostPaymentRequestAsync(externalCollectionRequest);
            return ConvertToCollection(collection, collectionResponse);           
        }

        private Collection ConvertToCollection(Collection collection, ExternalCollectionResponse externalCollectionResponse)
        {

            collection.CollectionResponse = new CollectionResponse
            {
                ResponseCode = externalCollectionResponse.ResponseCode
            };

            return collection;
        }

        private ExternalCollectionRequest ConvertToCollectionRequest(Collection collection)
        {
            return new ExternalCollectionRequest
            {
                Amount = collection.CollectionRequest.Amount,
                Currency = collection.CollectionRequest.Currency,
                ExternalId = collection.CollectionRequest.TransactionId,
                Payer = ConvertToPayer(collection),
                PayerMessage = collection.CollectionRequest.Memo,
                PayeeNote = collection.CollectionRequest.PayeeMessage
            };
        }

        private ExternalPayer ConvertToPayer(Collection collection)
        {
            return new ExternalPayer
            {
                PartyIdType = "MSISDN",
                PartyId = collection.CollectionRequest.Payer.PartyId,
            };
        }
    }
}