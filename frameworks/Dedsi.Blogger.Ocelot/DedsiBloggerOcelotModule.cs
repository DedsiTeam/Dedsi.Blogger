using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Ocelot;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
)]
public abstract class DedsiBloggerOcelotModule : AbpModule
{
    protected abstract string[] ApiServiceNames { get; set; }
    protected abstract string ApiServiceVersion { get; set; }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.AddOcelotConsul();
        context.ConfigureSwaggerServices(ApiServiceVersion, ApiServiceNames);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        context.UseOcelotSwaggerUI(ApiServiceVersion, ApiServiceNames);
        context.UseHealthCheck();
        context.UseOcelotWait();
    }
    
}

