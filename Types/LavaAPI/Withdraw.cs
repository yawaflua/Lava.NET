using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class WithdrawInfo : IBase
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string amount { get; set; }
        public string commission { get; set; }
        public string status { get; set; }
        public string service { get; set; }
        public string comment { get; set; }
        public string currency { get; set; }
    }
    public class Withdraw : IBase
    {
        public string account { get; set; }
        public float amount { get; set; }
        public string order_id { get; set; }
        public string hook_url { get; set; }
        public int subtract { get; set; } = 0;
        public string service { get; set; } = "card";
        public string wallet_to { get; set; }
        public string comment { get; set; }
        public string sbp_bank_id { get; set; }
    }
    
}
