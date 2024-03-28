using Dedsi.Blogger.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Identity;

[DependsOn(
    typeof(DedsiBloggerDomainModule),
    typeof(IdentityDomainSharedModule)
)]
public class IdentityDomainModule : AbpModule
{

}
