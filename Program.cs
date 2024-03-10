using Lava.NET.Types.Enums;
using Lava.NET.Types.LavaAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Lava.NET
{
    /// <summary>
    /// Ограниченный класс, который используется как базовый для бизнес части и публичной части Lava API. Использование нежелательно!
    /// </summary>
    /// <param name="token">Токен от Lava.ru</param>
    /// <param name="type">Тип вашего аккаунта</param>
    public  class LavaAPI(string token, LavaType type)
    {
        internal readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new("https://api.lava.ru/")
        };
        /// <summary>
        /// Отправка запроса на сервер
        /// </summary>
        /// <param name="path">path метода</param>
        /// <param name="neededType">требуемый тип аккаунта</param>
        /// <param name="method">Метод для отправки запроса</param>
        /// <param name="body">string body</param>
        /// <returns>string от сервера</returns>
        /// <exception cref="Exceptions.TypeException">Несоответсвие типа аккаунта и требуемого типа</exception>
        internal virtual async Task<string> SendRequest(string path, LavaType? neededType, HttpMethod method, string? body = null)
        {
            if (neededType != LavaType.any && neededType != type) throw new Exceptions.TypeException("Your Lava.ru account type is not equals needed type");
            _httpClient.DefaultRequestHeaders.Authorization = new("", token);
            using (var message = new HttpRequestMessage(method, _httpClient.BaseAddress + path))
            {
                
                message.Content = body == null ? new StringContent(body.ToString()) : null;
                var req = await _httpClient.SendAsync(message);
                return await req.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Создание ссылки на оплату (Выставление счета)
        /// </summary>
        /// <param name="data"> Данные, передаваемые в запрос. Смотреть АПИ</param>
        /// <returns>Ответ от сервера или null</returns>
        public virtual async Task<PaymentResponse?> CreatePaymentAsync(PaymentRequest data)
            => JsonConvert.DeserializeObject<PaymentResponse>(await SendRequest("invoice/create", LavaType.any, HttpMethod.Post, data.ToString()));
        /// <summary>
        /// Получение информации о выставленном счете, в т.ч. о том, оплачен ли счет
        /// </summary>
        /// <param name="id">айди выставленного счета</param>
        /// <returns>Ответ от сервера или null</returns>
        public virtual async Task<PaymentInfo?> GetPaymentInfoAsync(string id)
            => JsonConvert.DeserializeObject<PaymentInfo>(await SendRequest("invoice/info", LavaType.any, HttpMethod.Post, id));
        /// <summary>
        /// Установка webhook для получения информации о пополнениях, оплате выставленных счетов и т.д.
        /// </summary>
        /// <param name="url">HTTPS url до вашего бекенда, куда должен приходить вебхук</param>
        /// <returns></returns>
        public async Task SetWebhookUrl(string url)
            => await SendRequest("invoice/set-webhook", LavaType.any, HttpMethod.Post, url);
        /// <summary>
        /// Проверка токена
        /// </summary>
        /// <returns></returns>
        public async Task<bool> pingAsync()
            => JsonNode.Parse(await SendRequest("test/ping", LavaType.any, HttpMethod.Get))?["status"]?.ToString().Equals(true) ?? false;
    }
    public sealed class PublicLavaAPI : LavaAPI
    {
        /// <summary>
        /// Для обычных юзеров, т.е. вкладка Кошелек
        /// </summary>
        /// <param name="token">токен от вашего аккаунта</param>
        public PublicLavaAPI(string token) : base(token, LavaType.wallet) { }

        /// <summary>
        /// Получение кошельков на вашем аккаунте
        /// </summary>
        /// <returns>Список из кошельков или null</returns>
        public async Task<Wallet[]?> getWallets()
            => JsonConvert.DeserializeObject<Wallet[]>(await SendRequest("wallet/list", LavaType.wallet, HttpMethod.Get));
        /// <summary>
        /// Cоздние заявки на вывод
        /// </summary>
        /// <param name="withdraw">данные, передаваемые в запрос</param>
        /// <returns>Стандартный ответ от сервера или null</returns>
        public async Task<DefaultResponse?> MakeWithdraw(Withdraw withdraw)
            => JsonConvert.DeserializeObject<DefaultResponse>(await SendRequest("withdraw/create", LavaType.wallet, HttpMethod.Post, withdraw.ToString()));
        /// <summary>
        /// Информация о выводе
        /// </summary>
        /// <param name="id">Id заявки</param>
        /// <returns>Информация о выводе</returns>
        public async Task<WithdrawInfo?> InfoWithdrawAsync(string id)
            => JsonConvert.DeserializeObject<WithdrawInfo>(await SendRequest("withdraw/info", LavaType.wallet, HttpMethod.Post, id));
        /// <summary>
        /// Создание перевода
        /// </summary>
        /// <param name="data">Данные, передаваемые в запрос</param>
        /// <returns>Стандартный ответ от сервера или null</returns>
        public async Task<DefaultResponse?> MakeTransfer(Transfer data)
            => JsonConvert.DeserializeObject<DefaultResponse>(await SendRequest("transfer/create", LavaType.wallet, HttpMethod.Post, data.ToString()));
        /// <summary>
        /// Получение информации о переводе
        /// </summary>
        /// <param name="id">Id перевода</param>
        /// <returns>Данные о переводе</returns>
        public async Task<TransferData?> GetTransferDataAsync(string id)
            => JsonConvert.DeserializeObject<TransferData>(await SendRequest("transfer/info", LavaType.wallet, HttpMethod.Post, id));
        /// <summary>
        /// Получение всех транзакций
        /// </summary>
        /// <param name="transaction">Необ. данные для настройки вывода</param>
        /// <returns>Все транзакции</returns>
        public async Task<Transaction[]?> GetTransactionsAsync(TransactionParam? transaction = null)
            => JsonConvert.DeserializeObject<Transaction[]>(await SendRequest("transactions/list", LavaType.wallet, HttpMethod.Post, transaction?.ToString()));
        /// <summary>
        /// Получение банков, подключенных к СБП
        /// </summary>
        /// <returns>Список банков</returns>
        public async Task<SBPBanks?> GetSBPBanksAsync()
            => JsonConvert.DeserializeObject<SBPBanks>(await SendRequest("withdraw/get-sbp-bank-list", LavaType.wallet, HttpMethod.Post));
    }
    /// <summary>
    /// В РАЗРАБОТКЕ
    /// Часть lava.ru API, которая работает с бизнесом. Вкладка "Бизнес" dev.lava.ru
    /// </summary>
    /// <param name="token">Токен вашего аккаунта</param>
    public sealed class BusinessLavaAPI(string token) : LavaAPI(token, LavaType.business)
    {
        internal async Task<string> SendRequest(string path, LavaType? neededType = LavaType.business, HttpMethod? method = null, string? body = null, bool isSpecial = true)
        {
            method ??= HttpMethod.Post;
            if (neededType != LavaType.any && neededType != LavaType.business) throw new Exceptions.TypeException("Your Lava.ru account type is not equals needed type");
            _httpClient.DefaultRequestHeaders.Authorization = new("", token);
            if (isSpecial)
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
                _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            }
            using (var message = new HttpRequestMessage(method, path))
            {
                message.Content = body == null ? new StringContent(body.ToString()) : null;
                var req = await _httpClient.SendAsync(message);
                return await req.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Создание вывода 
        /// </summary>
        /// <param name="request">Данные, передаваемые в запрос</param>
        /// <returns></returns>
        public async Task<PayoffResponse?> CreatePayoffAsync(PayoffRequest request)
            => JsonConvert.DeserializeObject<PayoffResponse>(await SendRequest("business/payoff/create", body: request.ToString()));
        public async Task<PayoffDataResponse?> GetPayoffDataAsync(PayoffDataRequest request)
            => JsonConvert.DeserializeObject<PayoffDataResponse>(await SendRequest("business/payoff/info", body: request.ToString()));
        public async Task<PayoffTariffResponse?> GetPayoffTariffAsync(PayoffTariffRequest request)
            => JsonConvert.DeserializeObject<PayoffTariffResponse>(await SendRequest("business/payoff/get-tariffs", body: request.ToString()));
        public async Task<PayoffCheckoutResponse?> CheckPayoffTariffAsync(PayoffCheckoutRequest request)
            => JsonConvert.DeserializeObject<PayoffCheckoutResponse>(await SendRequest("business/payoff/check-wallet", body: request.ToString()));
        // В разработке...
    }
}
