using Dedsi.Blogger.Application.Contracts;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.FileCenter;

[DependsOn(
    typeof(FileCenterDomainSharedModule),
    typeof(DedsiBloggerApplicationContractsModule)
)]
public class FileCenterApplicationContractsModule : AbpModule
{

}
