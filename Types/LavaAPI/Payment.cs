using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class PaymentRequest : IBase
    {
        /// <summary>
        /// Ваш номер счета
        /// </summary>
        public string wallet_to { get; set; }
        /// <summary>
        /// Сумма с копейками и f на конце
        /// Пример: 1.00f
        /// </summary>
        public float sum { get; set; } = 1.00f;
        /// <summary>
        /// Уникальный номер счета в вашей системе
        /// </summary>
        public string? order_id { get; set; } 
        /// <summary>
        /// Url для отправки webhook
        /// </summary>
        public string? hook_url { get; set; } 
        /// <summary>
        /// Url для переадресации в случае успешной оплаты
        /// </summary>
        public string? success_url { get; set; }
        /// <summary>
        /// Url для переадресации в случае неуспешной оплаты
        /// </summary>
        public string? fail_url { get; set; }
        /// <summary>
        /// Время жизни счета в минутах
        /// Мин: 1 ; Макс: 43200
        /// </summary>
        public int? expire { get; set; } = 43200;
        /// <summary>
        /// С кого списывать комиссию:
        /// 1 - с клиента
        /// 0 - с магазина
        /// </summary>
        public string? subtract { get; set; } 
        /// <summary>
        /// Дополнительные данные предаваемые в вебхуке
        /// </summary>
        public string? custom_fields { get; set; } 
        /// <summary>
        /// Комментарий
        /// </summary>
        public string? comment { get; set; } 
        /// <summary>
        /// ID марчанта(только в вебхуке)
        /// </summary>
        public string? merchant_id { get; set; }
        /// <summary>
        /// Название мерчанта (отображается в форме перевода)
        /// </summary>
        public string? merchant_name { get; set; }
    }
    public class PaymentResponse : IBase
    {
        /// <summary>
        /// Статус запроса
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Номер счета на оплату
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Ссылка на оплату
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Время истечения счета
        /// </summary>
        public int expire { get; set; }
        /// <summary>
        /// Сумма счета
        /// </summary>
        public string sum { get; set; }
        /// <summary>
        ///  // URL для переадресации после успешной оплаты
        /// </summary>
        public string success_url { get; set; }
        /// <summary> 
        /// URL для переадресации после неудачной оплаты 
        /// </summary>
        public string fail_url { get; set; }
        /// <summary>
        /// адрес для вебхука
        /// </summary>
        public string hook_url { get; set; }
        /// <summary>
        /// Дополнительное поле
        /// </summary>
        public string custom_fields { get; set; }
        /// <summary>
        /// ID и наименование мерчанта
        /// </summary>
        public string merchant_name { get; set; }
        /// <summary>
        /// ID и наименование мерчанта
        /// </summary>

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
