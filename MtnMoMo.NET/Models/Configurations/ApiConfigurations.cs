using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtnMoMo.NET.Models.Configurations
{
    internal class ApiConfigurations
    {
        public string BaseUrl { get; set; }
        public string TargetEnvironment { get; set; }
        public string ApiUser { get; set; }
        public string ApiKey { get; set; }
        public string SubscriptionKey { get; set; }
        public string AccessToken { get; set; }
    }
}