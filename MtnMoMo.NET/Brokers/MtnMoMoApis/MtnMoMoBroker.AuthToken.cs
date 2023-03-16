using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MtnMoMo.NET.Models.ExternalProducts;

namespace MtnMoMo.NET.Brokers.MtnMoMoApis
{
    internal partial class MtnMoMoBroker
    {       
        public async ValueTask<AuthTokenResponse> GetAuthTokenAsync() =>
            await GetAuthAsync<AuthTokenResponse>(relativeUrl: "collection/token/");
    }
}


