# Lava.NET
���������� ��� ������ � API ����� lava.ru.
���� ��� ������� ������ ��� ������-������ API

���������� ����� �������������� ��������� [API ����� lava.ru](https://dev.lava.ru/)
# �������
## ��������� ����������
```bash
dotnet add package Lava.NET
```
### � �������������� � �������
```cs
using Lava.NET;
public class Program 
{
    public static async Task Main(string[] args)
    {
        var publicLavaApi = new PublicLavaAPI("[ ��� ����� ]");
        // ... ���� ������
    }
}
```
## ������ ������������� � ASP.NET �����������:
```cs
// Startup.cs

public void ConfigureServices(IServiceCollection services)
{
    var publicLavaApi = new PublicLavaAPI("[ ��� ����� ]");
    services.AddControllers();
    services
            
            .AddSwaggerGen();

    services
        // ...��������� ����������
        .AddSingleton(publicLavaAPI);
}
```

## ������ ������ � ��������(.NET 8):
```cs
// PaymentController.cs

[ApiController]
[Route("/payment/")]
public class PaymentController(PublicLavaAPI lavaAPI) : ControllerBase
{
        

    [HttpPost("lava")]
    public async Task<IActionResult> ValidatePaymentLava([FromBody] WebhookResponse webhookResponse)
    {
        // ���� ������
        
        return Ok(); // ����������� �������� 200, ����� ������� ����� ��������� ����� � �����, �� 15 ���. 
    }
}
```

## �������� ������ �� ������:
```cs
var publicLavaApi = new PublicLavaAPI("[��� �����]");
var createdPayment = await publicLavaApi.CreatePaymentAsync(
	new (){
            comment = "������ ������� � Telegram ����", // ����.
            hook_url = $"https://example.com/api/payment/lava", // ����.
            merchant_id = "AskMeAboutBOT", // ����.
            merchant_name = "AskMeAboutBOT", // ����.
            custom_fields = $"����� ��������� ������, ������������ � webhook", // ����.
            success_url = $"https://example.com/", // ����.
            sum = 39.00f,
            wallet_to = "R123123123"
	}
);
Console.Out.WriteLine(createdPayment.url);

// >>> 'https://p2p.lava.ru/form?id=1ee31634-e3e0-34ce-1423-b5b4cb524c6a'
```
