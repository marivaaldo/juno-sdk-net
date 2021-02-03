# juno-sdk-net
.NET 5 wrapper for [Juno API 2.0](https://dev.juno.com.br/api/v2)

## How to Use

This minimal example shows how to use Public Key Service.

```csharp
var credentials = new Credentials
{
    ClientId = "<client id>",
    ClientSecret = "<client secret>",
    PrivateToken = "<private token>",
    PublicToken = "<public token>",
    ReferralToken = "<referral token>"
};

var client = new JunoClient(credentials, SandboxEnvironment.Instance);

var service = new PublicKeysService(client);

var publicKey = service.GetPublicKey(_Client.Credentials.PrivateToken);
```

SDK Extensions

```csharp
...
public void ConfigureServices(IServiceCollection services)
{
    ...

    var mvcBuilder = services.AddControllers();

    // This configure Juno SDK
    services.AddJunoSdk(mvcBuilder, credentials, sandbox: true);

    ...
}
...
```

```csharp
...
public class TestController : ControllerBase
{
    private readonly JunoServices _JunoServices;

    public TestController(JunoServices junoServices)
    {
        _JunoServices = junoServices;
    }

    ...
}
...
```

Implements `IWebhooksHandler` from 'Juno.Sdk.Webhooks' namespace  to handle `webhooks` notifications.

## TO-DO
- Implementar serviços de Assinaturas
- Implementar serviços de Pagamento de Contas
- Implementar serviços do PicPay
- Implementar serviços do Pix

## Links

- Juno Website: [juno.com.br](https://juno.com.br)
- Juno API 2.0: [https://dev.juno.com.br/api/v2](https://dev.juno.com.br/api/v2)
- GitHub Repo: [marivaaldo/juno-sdk-net](https://github.com/marivaaldo/juno-sdk-net)
