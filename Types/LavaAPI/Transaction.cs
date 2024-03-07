using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{

    public class TransactionParam : IBase
    {
        public string? transfer_type { get; set; }
        public string? account { get; set; }
        public string? period_start { get; set; }
        public string? period_end { get; set; }
        public int? offset { get; set; }
        public int? limit { get; set; }
    }

    public class Transaction : IBase
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public DateTime created_date { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string transfer_type { get; set; }
        public string comment { get; set; }
        public string method { get; set; }
        public string currency { get; set; }
        public string account { get; set; }
        public string commission { get; set; }
        public string type { get; set; }
        public string receiver { get; set; }
    }
}
