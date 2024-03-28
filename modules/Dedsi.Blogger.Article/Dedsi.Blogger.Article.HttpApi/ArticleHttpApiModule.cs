using Dedsi.Blogger.Article.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Article;

[DependsOn(
    typeof(ArticleApplicationContractsModule)
)]
public class ArticleHttpApiModule : AbpModule
{

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ArticleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ArticleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
