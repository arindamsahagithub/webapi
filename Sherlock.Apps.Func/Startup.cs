using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Sherlock.Apps.Func.Email;
using Sherlock.Apps.Utility;

[assembly: FunctionsStartup(typeof(Sherlock.Apps.Func.Startup))]
namespace Sherlock.Apps.Func
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;
            builder.Services.AddSingleton<RegexHelper>();
            builder.Services
                .AddScoped<IEmailFactory, EmailFactory>();
        }
    }
}