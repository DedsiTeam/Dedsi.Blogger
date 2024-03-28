using Localization.Resources.AbpUi;
using Dedsi.Blogger.FileCenter.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Dedsi.Blogger.FileCenter;

[DependsOn(
    typeof(FileCenterApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class FileCenterHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(FileCenterHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FileCenterResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
