using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoMo.NET.Models.Collections
{
    public class Collection
    {
       public CollectionRequest RecoveryRequest { get; set; }
       public OAuthResponse OAuthRespose { get; set; }
       public AccountBalanceResponse AccountBalanceResponse { get; set; }
    }
}