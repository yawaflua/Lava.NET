using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    public class Transfer : IBase
    {
        /// <summary>
        /// Номер кошелька с которого совершается перевод
        /// </summary>
        public string account_from { get; set; }
        /// <summary>
        /// Номер кошелька куда совершается перевод 
        /// </summary>
        public string account_to { get; set;}
        /// <summary>
        /// Откуда списывать комиссию
        /// 1 - с баланса, 0 - с суммы
        /// </summary>
        public int? substract { get; set; } = 0;
        /// <summary>
        /// Сумма вывода с копейками и f на конце
        /// Пример: 1.00f
        /// </summary>
        public float amount { get; set; } = 1.00f;
        /// <summary>
        /// Комментарий
        /// </summary>
        public string? comment { get; set; }
    }
    public class TransferData : IBase
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Время создания в unix
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// сумма
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string? comment { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public string receiver { get; set; }
        /// <summary>
        /// комиссия
        /// </summary>
        public string commission { get; set; }
        
    }
}
