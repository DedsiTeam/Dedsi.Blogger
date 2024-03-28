using Dedsi.Blogger.Application.Contracts;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Application;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(DedsiBloggerApplicationContractsModule)
)]
public class DedsiBloggerApplicationModule : AbpModule
{
    
}