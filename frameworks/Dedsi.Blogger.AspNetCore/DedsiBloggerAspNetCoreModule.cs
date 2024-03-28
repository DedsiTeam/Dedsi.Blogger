using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.AspNetCore;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
)]
public class DedsiBloggerAspNetCoreModule : AbpModule
{

}