using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoMo.NET.Models.Recoveries
{
    public class AccountBalanceResponse
    {
        public int AvailableBalance { get; set; }
        public string Currency { get; set; }
    }
}