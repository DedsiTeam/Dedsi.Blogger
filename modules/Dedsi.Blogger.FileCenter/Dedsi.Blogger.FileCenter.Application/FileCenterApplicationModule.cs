using Dedsi.Blogger.Application;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.FileCenter;

[DependsOn(
    typeof(FileCenterDomainModule),
    typeof(FileCenterApplicationContractsModule),
    typeof(DedsiBloggerApplicationModule)
)]
public class FileCenterApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
