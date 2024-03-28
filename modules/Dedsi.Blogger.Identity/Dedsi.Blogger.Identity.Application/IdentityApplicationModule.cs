using Dedsi.Blogger.Application;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Identity;

[DependsOn(
    typeof(IdentityDomainModule),
    typeof(IdentityApplicationContractsModule),
    typeof(DedsiBloggerApplicationModule)
)]
public class IdentityApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
