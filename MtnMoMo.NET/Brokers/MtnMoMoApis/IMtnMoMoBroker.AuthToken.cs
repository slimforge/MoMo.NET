using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MtnMoMo.NET.Models.ExternalProducts;

namespace MtnMoMo.NET.Brokers.MtnMoMoApis
{
    internal partial interface IMtnMoMoBroker
    {
        ValueTask<AuthTokenResponse> GetAuthTokenAsync();
    }
}