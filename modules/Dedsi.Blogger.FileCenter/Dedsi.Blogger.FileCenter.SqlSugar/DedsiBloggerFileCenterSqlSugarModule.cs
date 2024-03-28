using Dedsi.Blogger.FileCenter;
using Dedsi.Blogger.SqlSugar;
using Dedsi.Blogger.SqlSugar.Extensions;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.FileCenter;

[DependsOn(
    typeof(DedsiBloggerSqlSugarModule)
)]
public class DedsiBloggerFileCenterSqlSugarModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.ConfigureSqlSugar(FileCenterDbProperties.ConnectionStringName);
    }
}