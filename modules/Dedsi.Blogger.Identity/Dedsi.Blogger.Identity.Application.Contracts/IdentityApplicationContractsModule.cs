using Dedsi.Blogger.Application.Contracts;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Identity;

[DependsOn(
    typeof(IdentityDomainSharedModule),
    typeof(DedsiBloggerApplicationContractsModule)
)]
public class IdentityApplicationContractsModule : AbpModule
{

}
