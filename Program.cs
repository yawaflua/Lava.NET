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
    public class ILavaAPI(string token, LavaType type)
    {
        internal readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new("https://api.lava.ru/")
        };
        internal async Task<string> SendRequest(string path, LavaType? neededType, HttpMethod method, string? body = null)
        {
            if (neededType != LavaType.any && neededType != type) throw new Exceptions.TypeException("Your Lava.ru account type is not equals needed type");
            _httpClient.DefaultRequestHeaders.Authorization = new("", token);
            using (var message = new HttpRequestMessage(method, path))
            {
                message.Content = body == null ? new StringContent(body.ToString()) : null;
                var req = await _httpClient.SendAsync(message);
                return await req.Content.ReadAsStringAsync();
            }
        }

        public async Task<PaymentResponse?> CreatePaymentAsync(PaymentRequest data)
            => JsonConvert.DeserializeObject<PaymentResponse>(await SendRequest("invoice/create", LavaType.any, HttpMethod.Post, data.ToString()));
        public async Task<PaymentInfo?> GetPaymentInfoAsync(string id)
            => JsonConvert.DeserializeObject<PaymentInfo>(await SendRequest("invoice/info", LavaType.any, HttpMethod.Post, id));
        public async Task SetWebhookUrl(string url)
            => await SendRequest("invoice/set-webhook", LavaType.any, HttpMethod.Post, url);
        public async Task<bool> pingAsync()
            => JsonNode.Parse(await SendRequest("test/ping", LavaType.any, HttpMethod.Get))?["status"]?.ToString().Equals(true) ?? false;
    }
    public class PublicLavaAPI : ILavaAPI
    {
        // Для обычных юзеров + общедоступное
        public PublicLavaAPI(string token) : base(token, LavaType.wallet) { }

        public async Task<Wallet[]?> getWallets()
            => JsonConvert.DeserializeObject<Wallet[]>(await SendRequest("wallet/list", LavaType.wallet, HttpMethod.Get));
        public async Task<DefaultResponse?> MakeWithdraw(Withdraw withdraw)
            => JsonConvert.DeserializeObject<DefaultResponse>(await SendRequest("withdraw/create", LavaType.wallet, HttpMethod.Post, withdraw.ToString()));
        public async Task<WithdrawInfo?> InfoWithdrawAsync(string id)
            => JsonConvert.DeserializeObject<WithdrawInfo>(await SendRequest("withdraw/info", LavaType.wallet, HttpMethod.Post, id));
        public async Task<DefaultResponse?> MakeTransfer(Transfer data)
            => JsonConvert.DeserializeObject<DefaultResponse>(await SendRequest("transfer/create", LavaType.wallet, HttpMethod.Post, data.ToString()));
        public async Task<TransferData?> GetTransferDataAsync(string id)
            => JsonConvert.DeserializeObject<TransferData>(await SendRequest("transfer/info", LavaType.wallet, HttpMethod.Post, id));
        public async Task<Transaction[]?> GetTransactionsAsync(TransactionParam? transaction = null)
            => JsonConvert.DeserializeObject<Transaction[]>(await SendRequest("transactions/list", LavaType.wallet, HttpMethod.Post, transaction?.ToString()));
        public async Task<SBPBanks?> GetSBPBanksAsync()
            => JsonConvert.DeserializeObject<SBPBanks>(await SendRequest("withdraw/get-sbp-bank-list", LavaType.wallet, HttpMethod.Post));
    }
    public class BusinessLavaAPI(string token) : ILavaAPI(token, LavaType.business)
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
