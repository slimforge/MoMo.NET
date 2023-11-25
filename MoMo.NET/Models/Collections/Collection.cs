using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoMo.NET.Models.Collections
{
    public class Collection
    {
       public CollectionRequest CollectionRequest { get; set; }
       public OAuthResponse OAuthRespose { get; set; }
       public AccountBalanceResponse AccountBalanceResponse { get; set; }

       public CollectionResponse CollectionResponse { get; set; }
    }
}