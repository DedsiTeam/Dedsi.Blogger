using Dedsi.Blogger.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.FileCenter;

[DependsOn(
    typeof(DedsiBloggerDomainModule),
    typeof(FileCenterDomainSharedModule)
)]
public class FileCenterDomainModule : AbpModule
{

}
