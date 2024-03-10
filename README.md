# Lava.NET
Библиотека для работы с API сайта lava.ru.
Пока что ведется работа над бизнес-частью API

Советуется перед использованием прочитать [API сайта lava.ru](https://dev.lava.ru/)
# Примеры
## Установка бибилотеки
```bash
dotnet add package Lava.NET
```
### И использлование в проекте
```cs
using Lava.NET;
public class Program 
{
    public static async Task Main(string[] args)
    {
        var publicLavaApi = new PublicLavaAPI("[ Ваш токен ]");
        // ... Ваша логика
    }
}
```
## Пример использования с ASP.NET приложением:
```cs
// Startup.cs

public void ConfigureServices(IServiceCollection services)
{
    var publicLavaApi = new PublicLavaAPI("[ Ваш токен ]");
    services.AddControllers();
    services
            
            .AddSwaggerGen();

    services
        // ...Настройка приложения
        .AddSingleton(publicLavaAPI);
}
```

## Пример работы с вебхуком(.NET 8):
```cs
// PaymentController.cs

[ApiController]
[Route("/payment/")]
public class PaymentController(PublicLavaAPI lavaAPI) : ControllerBase
{
        

    [HttpPost("lava")]
    public async Task<IActionResult> ValidatePaymentLava([FromBody] WebhookResponse webhookResponse)
    {
        // Ваша логика
        
        return Ok(); // Обязательно отвечать 200, иначе вебхуки будут приходить снова и снова, до 15 раз. 
    }
}
```

## Создание ссылки на оплату:
```cs
var publicLavaApi = new PublicLavaAPI("[Ваш токен]");
var createdPayment = await publicLavaApi.CreatePaymentAsync(
	new (){
            comment = "Оплата покупки в Telegram боте", // Необ.
            hook_url = $"https://example.com/api/payment/lava", // Необ.
            merchant_id = "AskMeAboutBOT", // Необ.
            merchant_name = "AskMeAboutBOT", // Необ.
            custom_fields = $"Любые кастомные данные, передаваемые в webhook", // Необ.
            success_url = $"https://example.com/", // Необ.
            sum = 39.00f,
            wallet_to = "R123123123"
	}
);
Console.Out.WriteLine(createdPayment.url);

// >>> 'https://p2p.lava.ru/form?id=1ee31634-e3e0-34ce-1423-b5b4cb524c6a'
```
