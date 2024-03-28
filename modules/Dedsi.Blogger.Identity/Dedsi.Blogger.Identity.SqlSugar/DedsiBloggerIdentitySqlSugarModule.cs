using Dedsi.Blogger.SqlSugar;
using Dedsi.Blogger.SqlSugar.Extensions;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Identity;

[DependsOn(
    typeof(DedsiBloggerSqlSugarModule)
)]
public class DedsiBloggerIdentitySqlSugarModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.ConfigureSqlSugar(IdentityDbProperties.ConnectionStringName);
    }
}