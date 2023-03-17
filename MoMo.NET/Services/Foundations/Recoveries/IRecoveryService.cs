// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System.Threading.Tasks;
using MoMo.NET.Models.Recoveries;

namespace MoMo.NET.Services.Foundations.Recoveries
{
    internal interface IRecoveryService
    {
       ValueTask<Recovery> AuthenticateClientAsync(); 
    }
}