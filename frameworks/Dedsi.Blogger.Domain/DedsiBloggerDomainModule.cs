using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Domain;


[DependsOn(
    typeof(AbpDddDomainModule)
)]
public class DedsiBloggerDomainModule : AbpModule
{
    
}