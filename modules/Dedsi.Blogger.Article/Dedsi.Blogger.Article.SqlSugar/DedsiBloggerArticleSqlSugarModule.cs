using Dedsi.Blogger.Article;
using Dedsi.Blogger.SqlSugar;
using Dedsi.Blogger.SqlSugar.Extensions;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Article;

[DependsOn(
    typeof(DedsiBloggerSqlSugarModule)
)]
public class DedsiBloggerArticleSqlSugarModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.ConfigureSqlSugar(ArticleDbProperties.ConnectionStringName);
    }
}