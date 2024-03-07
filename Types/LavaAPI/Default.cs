using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class DefaultResponse : IBase
    {
        public string id { get; set; }
        public string status { get; set; }
        public string amount { get; set; }
        public int commission { get; set; }
    }

}
