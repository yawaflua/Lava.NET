using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class Transfer : IBase
    {
        public string account_from { get; set; }
        public string account_to { get; set;}
        public int substract { get; set; } = 0;
        public int amount { get; set; }
        public string? comment { get; set; }
    }
    public class TransferData : IBase
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public object comment { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string receiver { get; set; }
        public string commission { get; set; }
    }
}
