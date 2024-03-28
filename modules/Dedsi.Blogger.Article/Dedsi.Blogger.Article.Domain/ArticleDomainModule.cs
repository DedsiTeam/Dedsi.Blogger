using Dedsi.Blogger.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Article;

[DependsOn(
    typeof(DedsiBloggerDomainModule),
    typeof(ArticleDomainSharedModule)
)]
public class ArticleDomainModule : AbpModule
{

}
