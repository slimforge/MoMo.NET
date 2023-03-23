// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System.Threading.Tasks;
using MoMo.NET.Models.Collections;

namespace MoMo.NET.Services.Foundations.Collections
{
    internal interface ICollectionService
    {
       ValueTask<Collection> AuthenticateClientAsync(); 
       ValueTask<Collection> PromptRecoveryAsync(Collection recoveryRequest); 
    }
}