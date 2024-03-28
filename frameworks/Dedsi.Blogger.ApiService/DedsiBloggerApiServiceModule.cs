using Dedsi.Blogger.AspNetCore;
using Dedsi.Blogger.AspNetCore.Extensions;
using Dedsi.Blogger.Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.ApiService;

[DependsOn(
    typeof(DedsiBloggerConsulModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAutofacModule)
)]
public abstract class DedsiBloggerApiServiceModule : AbpModule
{
    protected abstract string ApiServiceName { get; }
    
    protected abstract string ApiServiceVersion { get; }
    
    protected abstract string RedisKeyPrefix { get; }

    protected abstract void ConfigureApiServices(ServiceConfigurationContext context);
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 时间格式 
        Configure<AbpJsonOptions>(options =>
        {
            options.OutputDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        });
        
        // 国际化
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        });
        
        // 日志
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = ApiServiceName;
            options.IsEnabledForGetRequests = true;
        });
        
        // Swagger
        context.ConfigureSwaggerServices(ApiServiceName,ApiServiceVersion);
        
        ConfigureApiServices(context);
    }

    protected abstract void OnApiServiceInitialization(ApplicationInitializationContext context);
    
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors();

        // Swagger
        context.UseSwaggerServices(ApiServiceName,ApiServiceVersion);
        
        OnApiServiceInitialization(context);

        app.UseAuthentication();
        app.UseAbpRequestLocalization();
        app.UseAuthorization();

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
    
}