using Dedsi.Blogger.Application;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Article;

[DependsOn(
    typeof(ArticleDomainModule),
    typeof(ArticleApplicationContractsModule),
    typeof(DedsiBloggerApplicationModule)
)]
public class ArticleApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
