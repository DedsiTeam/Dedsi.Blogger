using Dedsi.Blogger.ApiService;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Identity.ApiService;

[DependsOn(
    typeof(IdentityApplicationModule),
    typeof(DedsiBloggerIdentitySqlSugarModule),
    typeof(IdentityHttpApiModule)
)]
public class DedsiBloggerIdentityApiServiceModule : DedsiBloggerApiServiceModule
{
    protected override string ApiServiceName => IdentityRemoteServiceConsts.ModuleName;
    protected override string ApiServiceVersion => "V1";
    protected override string RedisKeyPrefix => ApiServiceName;
    
    protected override void ConfigureApiServices(ServiceConfigurationContext context)
    {

    }

    protected override void OnApiServiceInitialization(ApplicationInitializationContext context)
    {

    }
}