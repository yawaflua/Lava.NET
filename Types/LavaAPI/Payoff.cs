using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.LavaAPI
{
    /// <summary>
    /// Параметры запроса на вывод средств.
    /// </summary>
    public class PayoffRequest : IBase
    {
        /// <summary>
        /// Сумма вывода.
        /// </summary>
        public double amount { get; set; }

        /// <summary>
        /// Уникальный идентификатор платежа в системе мерчанта.
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Подпись запроса.
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public Guid shopId { get; set; }

        /// <summary>
        /// Куда отправлять хук (Max: 500).
        /// </summary>
        public string hookUrl { get; set; }

        /// <summary>
        /// Сервис, на который производится вывод средств.
        /// </summary>
        public string service { get; set; }

        /// <summary>
        /// Номер кошелька, на который производится вывод средств.
        /// При выводе на свой лава кошелёк параметр не указывается.
        /// </summary>
        public string walletTo { get; set; }

        /// <summary>
        /// С кого списывать коммиссию: с магазина или с суммы.
        /// По умолчанию 0, 1 - с магазина, 0 - с суммы.
        /// </summary>
        public string subtract { get; set; }
    }
    public class Data : IBase
    {
        public string payoff_id { get; set; }
        public string payoff_status { get; set; }
    }
    public class PayoffResponse : IBase
    {
        public Data data { get; set; }
        public int status { get; set; }
        public bool status_check { get; set; }
    }
    /// <summary>
    /// Параметры запроса.
    /// </summary>
    public class PayoffDataRequest : IBase
    {
        /// <summary>
        /// Подпись запроса.
        /// </summary>
        public string? signature { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public Guid shopId { get; set; }

        /// <summary>
        /// Уникальный идентификатор платежа в системе мерчанта.
        /// </summary>
        public Guid? orderId { get; set; }

        /// <summary>
        /// Номер вывода.
        /// </summary>
        public Guid? payoffId { get; set; }
    }
    public class ResponseData : IBase
    {
        public string id { get; set; }
        public object orderId { get; set; }
        public string status { get; set; }
        public string wallet { get; set; }
        public string service { get; set; }
        public int amountPay { get; set; }
        public double commission { get; set; }
        public double amountReceive { get; set; }
        public int tryCount { get; set; }
        public object errorMessage { get; set; }
    }
    public class PayoffDataResponse : IBase
    {
        public ResponseData data { get; set; }
        public int status { get; set; }
        public bool status_check { get; set; }
    }
    public class PayoffTariffData : IBase
    {
        public List<Tariff> tariffs { get; set; }
    }
    public class PayoffTariffResponse : IBase
    {
        public PayoffTariffData data { get; set; }
        public int status { get; set; }
        public bool status_check { get; set; }
    }
    public class PayoffTariffRequest : IBase
    {
        /// <summary>
        /// Подпись запроса.
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public Guid shopId { get; set; }
    }
    public class Tariff : IBase
    {
        public double percent { get; set; }
        public int min_sum { get; set; }
        public int max_sum { get; set; }
        public string service { get; set; }
        public int fix { get; set; }
        public string title { get; set; }
        public string currency { get; set; }
    }
    /// <summary>
    /// Класс, представляющий параметры запроса.
    /// </summary>
    public class PayoffCheckoutRequest : IBase
    {
        /// <summary>
        /// Кошелёк/аккаунт.
        /// </summary>
        public string walletTo { get; set; }

        /// <summary>
        /// Сервис для выплаты.
        /// Тип: ['card_payoff', 'qiwi_payoff', 'lava_payoff', 'steam_payoff']
        /// </summary>
        public string service { get; set; } 
        /// <summary>
        /// Подпись запроса
        /// </summary>
        public string? signature { get; set; } 
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Guid shopId { get; set; } 
    }
    public class PayoffData
    {
        public bool status { get; set; }
    }

    public class PayoffCheckoutResponse
    {
        public PayoffData data { get; set; }
        public int status { get; set; }
        public bool status_check { get; set; }
    }
}
