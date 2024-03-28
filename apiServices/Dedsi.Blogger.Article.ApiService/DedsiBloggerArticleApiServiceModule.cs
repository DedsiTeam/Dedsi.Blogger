using Dedsi.Blogger.ApiService;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Article.ApiService;

[DependsOn(
    typeof(ArticleApplicationModule),
    typeof(DedsiBloggerArticleSqlSugarModule),
    typeof(ArticleHttpApiModule)
)]
public class DedsiBloggerArticleApiServiceModule : DedsiBloggerApiServiceModule
{
    protected override string ApiServiceName => ArticleRemoteServiceConsts.ModuleName;
    protected override string ApiServiceVersion => "V1";
    protected override string RedisKeyPrefix => ApiServiceName;

    protected override void ConfigureApiServices(ServiceConfigurationContext context)
    {
        
    }

    protected override void OnApiServiceInitialization(ApplicationInitializationContext context)
    {
        
    }
    
}