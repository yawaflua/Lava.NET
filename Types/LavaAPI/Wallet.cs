using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class Wallet : IBase
    {
        public string account { get; set; }
        public string currency { get; set; }
        public string balance { get; set; }
    }
}
