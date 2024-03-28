using Dedsi.Blogger.AspNetCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Consul;

[DependsOn(
    typeof(DedsiBloggerAspNetCoreModule)
)]
public class DedsiBloggerConsulModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        Configure<ConsulConfigOptions>(configuration.GetSection(ConsulConfigOptions.Key));
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        context.UseConsul();
    }
}