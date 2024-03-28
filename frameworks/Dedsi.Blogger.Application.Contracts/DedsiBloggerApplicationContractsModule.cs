using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Application.Contracts;

[DependsOn(
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class DedsiBloggerApplicationContractsModule : AbpModule
{
    
}