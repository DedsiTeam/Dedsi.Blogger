using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.SqlSugar;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
)]
public class DedsiBloggerSqlSugarModule : AbpModule
{

}