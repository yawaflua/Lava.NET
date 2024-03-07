using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class Datum : IBase
    {
        public object id { get; set; }
        public string name { get; set; }
    }

    public class SBPBanks : IBase
    {
        public List<Datum> data { get; set; }
    }
}
