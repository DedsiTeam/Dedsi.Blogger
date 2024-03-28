using Dedsi.Blogger.Application.Contracts;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Article;

[DependsOn(
    typeof(ArticleDomainSharedModule),
    typeof(DedsiBloggerApplicationContractsModule)
)]
public class ArticleApplicationContractsModule : AbpModule
{

}
