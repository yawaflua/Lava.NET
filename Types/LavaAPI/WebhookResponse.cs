using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class WebhookResponse : IBase
    {
        public int type { get; set; }
        public string invoice_id { get; set; }
        public string order_id { get; set; }
        public string status { get; set; }
        public int pay_time { get; set; }
        public string amount { get; set; }
        public string custom_fields { get; set; }
        public string credited { get; set; }
        public string merchant_id { get; set; }
        public string merchant_name { get; set; }
        public string sign { get; set; }
    }
}
