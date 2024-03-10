using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class WithdrawInfo : IBase
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Время создания (В формате unix timestamp)
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// Сумма заявки
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Комиссия
        /// </summary>
        public string commission { get; set; }
        /// <summary>
        /// Статус заявки
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Сервис
        /// </summary>
        public string service { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string? comment { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public string currency { get; set; }
    }
    public class Withdraw : IBase
    {
        /// <summary>
        /// Номер кошелька, с которго совершается вывод
        /// </summary>
        /// <example>
        /// R40510054
        /// </example>
        public string account { get; set; }
        /// <summary>
        /// Сумма вывода
        /// </summary>
        public float amount { get; set; }
        /// <summary>
        /// Номер счета в вашей системе
        /// Должен быть уникальным
        /// </summary>
        public string? order_id { get; set; }
        /// <summary>
        /// Url для отправки Webhook 
        /// </summary>
        public string? hook_url { get; set; }
        /// <summary>
        /// Откуда списывать комиссию
        ///
        /// 1 - с баланса, 0 - с суммы
        /// Если параметр не передан, то комиссия берется с суммы
        /// </summary>
        public int? subtract { get; set; } = 0;
        /// <summary>
        /// Сервис вывода
        /// Пример: card
        /// </summary>
        public string? service { get; set; } = "card";
        /// <summary>
        /// Номер счета получателя
        /// </summary>
        public string? wallet_to { get; set; }
        /// <summary>
        /// Комментарий к выводу
        /// </summary>
        public string? comment { get; set; }
        /// <summary>
        /// ID банка в СБП
        /// </summary>
        public string? sbp_bank_id { get; set; }
    }
    
}
