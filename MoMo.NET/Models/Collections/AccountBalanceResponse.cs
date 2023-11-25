using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoMo.NET.Models.Collections
{
    public class AccountBalanceResponse
    {
        public int AvailableBalance { get; set; }
        public string Currency { get; set; }
    }
}