using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class PaymentRequest : IBase
    {
        public string wallet_to { get; set; } 
        public float sum { get; set; } 
        public string? order_id { get; set; } 
        public string? hook_url { get; set; } 
        public string? success_url { get; set; } 
        public string? fail_url { get; set; }
        public int? expire { get; set; } = 43200;
        public string? subtract { get; set; } 
        public string? custom_fields { get; set; } 
        public string? comment { get; set; } 
        public string? merchant_id { get; set; }
        public string? merchant_name { get; set; }
    }
    public class PaymentResponse : IBase
    {
        public string status { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int expire { get; set; }
        public string sum { get; set; }
        public string success_url { get; set; }
        public string fail_url { get; set; }
        public string hook_url { get; set; }
        public string custom_fields { get; set; }
        public string merchant_name { get; set; }
        public string merchant_id { get; set; }
    }
    public class Invoice : IBase
    {
        public string id { get; set; }
        public string order_id { get; set; }
        public int expire { get; set; }
        public string sum { get; set; }
        public string comment { get; set; }
        public string status { get; set; }
        public string success_url { get; set; }
        public string fail_url { get; set; }
        public string hook_url { get; set; }
        public string custom_fields { get; set; }
    }

    public class PaymentInfo : IBase
    {
        public string status { get; set; }
        public Invoice invoice { get; set; }
    }
}
