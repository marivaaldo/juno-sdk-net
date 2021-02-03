using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddJunoSdk(this IServiceCollection services, IMvcBuilder mvcBuilder, Credentials credentials, bool sandbox = false)
        {
            IEnvironment environment = sandbox ? SandboxEnvironment.Instance : ProductionEnvironment.Instance;

#if DEBUG
            environment = SandboxEnvironment.Instance;
#endif

            //
            // Cliente da API

            services.AddSingleton(new JunoClient(credentials, environment));

            //
            // Serviços da API

            services.AddSingleton<Services.AdditionalDataService>();
            services.AddSingleton<Services.BalancesService>();
            services.AddSingleton<Services.ChargesService>();
            services.AddSingleton<Services.DigitalAccountsService>();
            services.AddSingleton<Services.DocumentsService>();
            services.AddSingleton<Services.NotificationsService>();
            services.AddSingleton<Services.PaymentsService>();
            services.AddSingleton<Services.PublicKeysService>();
            services.AddSingleton<Services.TransfersService>();

            services.AddSingleton<Services.JunoServices>();

            //
            // Controllers

            mvcBuilder.AddApplicationPart(typeof(StartupExtensions).Assembly);

            services.AddMediatR(typeof(StartupExtensions).GetTypeInfo().Assembly);

            return services;
        }
    }
}
